using LanguageServer.Client;
using LanguageServer.Json;
using LanguageServer.Parameters.General;
using Matarillo.IO;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Text;

namespace LanguageServer
{
    /// <summary>
    /// rpc连接
    /// 提供基础的远程调用接口
    /// </summary>
    public class Connection
    {
        public delegate void Callback(string method);
        public delegate void RequestFinish(string method, int time);
        private readonly ProtocolReader input;
        private readonly Stream output;
        private const byte CR = 13;
        private const byte LF = 10;
        private readonly byte[] separator = [CR, LF];
        private readonly object outputLock = new();
        private readonly Proxy proxy;
        public readonly int timeout;
        /// <summary>
        /// 当请求执行时间大于<see cref="timeout"/>毫秒时会触发该事件。
        /// 仅在<see cref="timeout"/>大于0时有效。
        /// </summary>
        public event Callback? OnTimeout;
        /// <summary>
        /// 当超时请求完成时触发回调
        /// </summary>
        public event RequestFinish? OnTimeoutRequestFinish;
        public Proxy Proxy => proxy;

        private readonly RequestHandlerCollection RequestHandlers = new();
        private readonly NotificationHandlerCollection NotificationHandlers = new();
        private readonly ResponseHandlerCollection ResponseHandlers = new();
        private readonly CancellationHandlerCollection CancellationHandlers = new();
        /// <summary>
        /// rpc连接
        /// </summary>
        /// <param name="input">输入流</param>
        /// <param name="output">输出流</param>
        /// <param name="timeout">请求处理的超时时间，单位毫秒</param>
        [RequiresDynamicCode("Calls LanguageServer.Reflector.GetRequestType(MethodInfo)")]
        public Connection(Stream input, Stream output, int timeout)
        {
            this.input = new ProtocolReader(input);
            this.output = output;
            this.timeout = timeout;
            proxy = new Proxy(this);
            foreach (var method in GetType().GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly))
            {
                var rpcMethod = method.GetCustomAttribute<JsonRpcMethodAttribute>()?.Method;
                if (rpcMethod != null)
                {
                    if (Reflector.IsRequestHandler(method))
                    {
                        RequestHandlers.AddRequestHandler(new RequestHandler(
                            rpcMethod,
                            Reflector.GetRequestType(method),
                            Reflector.GetResponseType(method),
                            Reflector.CreateRequestHandlerDelegate(method)
                            ));
                    }
                    else if (Reflector.IsNotificationHandler(method))
                    {
                        NotificationHandlers.AddNotificationHandler(new NotificationHandler(
                            rpcMethod,
                            Reflector.GetNotificationType(method),
                            Reflector.CreateNotificationHandlerDelegate(method)
                            ));
                    }
                }
            }
        }
        public async Task Listen()
        {
            while (true)
            {
                try
                {
                    if (!await ReadAndHandle()) break;
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(ex);
                }
            }
        }
        private async Task<bool> ReadAndHandle()
        {
            var json = await Read();
            var messageTest = Serializer.Deserialize<MessageTest>(json);
            if (messageTest == null) return false;
            new Task(() =>
            {
                if (timeout > 0)
                {
                    var flag = false;
                    var begin = DateTime.Now;
                    Task.Run(() =>
                    {
                        Task.Delay(timeout).Wait();
                        if (!flag) OnTimeout?.Invoke(messageTest.method);
                    });
                    Processing(messageTest, json);
                    flag = true;
                    if (timeout > 0 && DateTime.Now - begin > TimeSpan.FromMilliseconds(timeout))
                        OnTimeoutRequestFinish?.Invoke(messageTest.method, (int)(DateTime.Now - begin).TotalMilliseconds);
                }
                else Processing(messageTest, json);
            }).Start();
            return true;
        }
        private void Processing(MessageTest test, string json)
        {
            if (test.IsRequest) HandleRequest(test.method, test.id, json);
            else if (test.IsResponse) HandleResponse(test.id, json);
            else if (test.IsCancellation) HandleCancellation(json);
            else if (test.IsNotification) HandleNotification(test.method, json);
        }

        private void HandleRequest(string method, NumberOrString id, string json)
        {
            if (RequestHandlers.TryGetRequestHandler(method, out var handler))
            {
                try
                {
                    var tokenSource = new CancellationTokenSource();
                    CancellationHandlers.AddCancellationTokenSource(id, tokenSource);
                    var request = Serializer.Deserialize(handler!.RequestType, json)!;
                    var requestResponse = (ResponseMessageBase)handler.Handle(request, this, tokenSource.Token);
                    CancellationHandlers.RemoveCancellationTokenSource(id);
                    requestResponse.id = id;
                    SendMessage(requestResponse);
                }
                catch (Exception e)
                {
                    Console.Error.WriteLine(e);
                    var requestErrorResponse = Reflector.CreateErrorResponse(handler!.ResponseType, id, e.ToString());
                    requestErrorResponse.id = id;
                    SendMessage(requestErrorResponse);
                }
            }
            else
            {
                Console.Error.WriteLine($"WARN: server does not support a request '{method}'");
            }
        }

        private void HandleResponse(NumberOrString id, string json)
        {
            if (ResponseHandlers.TryRemoveResponseHandler(id, out var handler))
            {
                var response = Serializer.Deserialize(handler!.ResponseType, json);
                handler.Handle(response!);
            }
            else
            {
                Console.Error.WriteLine($"WARN: server does not expect a response to '{id}'");
            }
        }

        private void HandleCancellation(string json)
        {
            var cancellation = Serializer.Deserialize<NotificationMessage<CancelParams>>(json);
            var id = cancellation!.@params!.id!;
            if (CancellationHandlers.TryRemoveCancellationTokenSource(id, out var tokenSource))
            {
                tokenSource!.Cancel();
            }
            else
            {
                Console.Error.WriteLine($"WARN: server can not cancel a procedure '{id}'");
            }
        }

        private void HandleNotification(string method, string json)
        {
            if (NotificationHandlers.TryGetNotificationHandler(method, out var handler))
            {
                var notification = Serializer.Deserialize(handler!.NotificationType, json);
                handler.Handle(notification!, this);
            }
            else
            {
                Console.Error.WriteLine($"WARN: server does not support a notification '{method}'");
            }
        }

        public void SendRequest<TRequest, TResponse>(TRequest request, Action<TResponse> responseHandler) where TRequest : RequestMessageBase where TResponse : ResponseMessageBase
        {
            var handler = new ResponseHandler(request.id!, typeof(TResponse), response => responseHandler((TResponse)response));
            ResponseHandlers.AddResponseHandler(handler);
            SendMessage(request);
        }

        public void SendNotification<TNotification>(TNotification notification) where TNotification : NotificationMessageBase
        {
            SendMessage(notification);
        }

        public void SendCancellation(NumberOrString id)
        {
            var message = new NotificationMessage<CancelParams> { method = "$/cancelRequest", @params = new CancelParams { id = id } };
            SendMessage(message);
        }

        private void SendMessage(MessageBase message)
        {
            Write(Serializer.Serialize(message));
        }

        private void Write(string json)
        {
            var utf8 = Encoding.UTF8.GetBytes(json);
            lock (outputLock)
            {
                using (var writer = new StreamWriter(output, Encoding.ASCII, 1024, true))
                {
                    writer.Write($"Content-Length: {utf8.Length}\r\n");
                    writer.Write("\r\n");
                    writer.Flush();
                }
                output.Write(utf8, 0, utf8.Length);
                output.Flush();
            }
        }

        private async Task<string> Read()
        {
            var contentLength = 0;
            var headerBytes = await input.ReadToSeparatorAsync(separator);
            while (headerBytes.Length != 0)
            {
                var headerLine = Encoding.ASCII.GetString(headerBytes);
                var position = headerLine.IndexOf(": ", StringComparison.Ordinal);
                if (position >= 0)
                {
                    var name = headerLine[..position];
                    var value = headerLine[(position + 2)..];
                    if (string.Equals(name, "Content-Length", StringComparison.Ordinal))
                    {
                        _ = int.TryParse(value, out contentLength);
                    }
                }
                headerBytes = await input.ReadToSeparatorAsync(separator);
            }
            if (contentLength == 0)
            {
                return "";
            }
            var contentBytes = await input.ReadBytesAsync(contentLength);
            return Encoding.UTF8.GetString(contentBytes);
        }
    }
}
