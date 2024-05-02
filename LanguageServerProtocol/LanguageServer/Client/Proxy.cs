using LanguageServer.Parameters.Client;

namespace LanguageServer.Client
{
    /// <summary>
    /// 用于将消息从服务器发送到客户机的代理类。
    /// </summary>
    /// <param name="connection"></param>
    public sealed class Proxy(Connection connection)
    {
        private WindowProxy? _window;
        private ClientProxy? _client;
        private WorkspaceProxy? _workspace;
        private TextDocumentProxy? _textDocument;

        /// <summary>
        /// 获取用于发送与窗口相关的消息的代理对象。
        /// </summary>
        public WindowProxy Window => _window ??= new WindowProxy(this);

        /// <summary>
        /// 获取用于发送与客户端相关的消息的代理对象。
        /// </summary>
        public ClientProxy Client => _client ??= new ClientProxy(this);

        /// <summary>
        /// 获取用于发送与工作区相关的消息代理对象。
        /// </summary>
        public WorkspaceProxy Workspace => _workspace ??= new WorkspaceProxy(this);

        /// <summary>
        /// 获取用于发送与文本文档相关的消息代理对象。
        /// </summary>
        public TextDocumentProxy TextDocument => _textDocument ??= new TextDocumentProxy(this);

        public void SendNotification<T>(string method, T param)
        {
            connection.SendNotification(new NotificationMessage<T>()
            {
                method = method,
                @params = param
            });
        }
        public Task<TResult> SendRequest<TParam, TResult>(string method, TParam param)
        {
            var task = new TaskCompletionSource<TResult>();
            connection.SendRequest<RequestMessage<TParam>, ResponseMessage<TResult, ResponseError>>(new RequestMessage<TParam>()
            {
                id = IdGenerator.Next(),
                method = method,
                @params = param
            }, res =>
            {
                if (res.result == null || task.TrySetResult(res.result))
                    task.TrySetException(new Exception(res.error?.message));
            });
            return task.Task;
        }
        public Task SendRequest<TParam>(string method, TParam param)
        {
            var task = new TaskCompletionSource();
            connection.SendRequest<RequestMessage<TParam>, VoidResponseMessage<ResponseError>>(new RequestMessage<TParam>()
            {
                id = IdGenerator.Next(),
                method = method,
                @params = param
            }, res =>
            {
                if (res.error != null) task.TrySetException(new Exception(res.error?.message));
                else task.TrySetResult();
            });
            return task.Task;
        }
        public Task<TResult> SendRequest<TResult>(string method)
        {
            var task = new TaskCompletionSource<TResult>();
            connection.SendRequest<VoidRequestMessage, ResponseMessage<TResult, ResponseError>>(new VoidRequestMessage()
            {
                id = IdGenerator.Next(),
                method = method
            }, res =>
            {
                if (res.result == null || task.TrySetResult(res.result))
                    task.TrySetException(new Exception(res.error?.message));
            });
            return task.Task;
        }
    }
}
