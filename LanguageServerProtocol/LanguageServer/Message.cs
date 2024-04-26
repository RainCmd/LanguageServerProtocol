using LanguageServer.Json;

namespace LanguageServer
{
    public static class Message
    {
        public static Result<T, TError> ToResult<T, TError>(ResponseMessage<T, TError> response) where TError : ResponseError
        {
            return (response.error == null)
                ? Result<T, TError>.Success(response.result)
                : Result<T, TError>.Error(response.error);
        }

        public static VoidResult<TError> ToResult<TError>(VoidResponseMessage<TError> response) where TError : ResponseError
        {
            return (response.error == null)
                ? VoidResult<TError>.Success()
                : VoidResult<TError>.Error(response.error);
        }

        public static ResponseError ParseError() => new(ErrorCodes.ParseError, "Parse error");
        public static ResponseError<T> ParseError<T>(T data) => new(ErrorCodes.ParseError, "Parse error") { data = data };

        public static ResponseError InvalidRequest() => new(ErrorCodes.InvalidRequest, "Invalid Request");
        public static ResponseError<T> InvalidRequest<T>(T data) => new(ErrorCodes.InvalidRequest, "Invalid Request") { data = data };

        public static ResponseError MethodNotFound() => new(ErrorCodes.MethodNotFound, "Method not found");
        public static ResponseError<T> MethodNotFound<T>(T data) => new(ErrorCodes.MethodNotFound, "Method not found") { data = data };

        public static ResponseError InvalidParams() => new(ErrorCodes.InvalidParams, "Invalid params");
        public static ResponseError<T> InvalidParams<T>(T data) => new(ErrorCodes.InvalidParams, "Invalid params") { data = data };

        public static TResponseError InternalError<TResponseError>() where TResponseError : ResponseError, new() => new() { code = ErrorCodes.InternalError, message = "Internal error" };
        public static ResponseError InternalError() => new(ErrorCodes.InternalError, "Internal error");
        public static ResponseError<T> InternalError<T>(T data) => new(ErrorCodes.InternalError, "Internal error") { data = data };

        public static ResponseError ServerError(ErrorCodes code) => new(code, "Server error");
        public static ResponseError<T> ServerError<T>(ErrorCodes code, T data) => new(code, "Server error") { data = data };
    }

    internal class MessageTest(string jsonrpc, NumberOrString id, string method)
    {
        public string jsonrpc = jsonrpc;

        public NumberOrString id = id;

        public string method = method;

        public bool IsMessage => jsonrpc == "2.0";

        public bool IsRequest => IsMessage && id != null && method != null;

        public bool IsResponse => IsMessage && id != null && method == null;

        public bool IsNotification => IsMessage && id == null && method != null;

        public bool IsCancellation => IsNotification && method == "$/cancelRequest";
    }

    public abstract class MessageBase
    {
        public string jsonrpc = "2.0";
    }

    public abstract class MethodCall : MessageBase
    {
        public string? method;
    }

    public abstract class RequestMessageBase : MethodCall
    {
        public NumberOrString? id;
    }

    public class VoidRequestMessage : RequestMessageBase
    {
    }

    public class RequestMessage<T> : RequestMessageBase
    {
        public T? @params;
    }

    public abstract class ResponseMessageBase : MessageBase
    {
        public NumberOrString? id;
    }

    public class VoidResponseMessage<TError> : ResponseMessageBase where TError : ResponseError
    {
        public TError? error;
    }

    public class ResponseMessage<T, TError> : ResponseMessageBase where TError : ResponseError
    {
        public T? result;

        public TError? error;
    }

    public abstract class NotificationMessageBase : MethodCall
    {
    }

    public class VoidNotificationMessage : NotificationMessageBase
    {
    }

    public class NotificationMessage<T> : NotificationMessageBase
    {
        public T? @params;
    }

    public class ResponseError(ErrorCodes code, string message)
    {
        public ErrorCodes code = code;
        public string message = message;
        public ResponseError() : this(ErrorCodes.UnknownErrorCode, "") { }
    }

    public class ResponseError<T>(ErrorCodes code, string message) : ResponseError(code, message)
    {
        public T? data;
        public ResponseError() : this(ErrorCodes.UnknownErrorCode, "") { }
    }

    public enum ErrorCodes
    {
        ParseError = -32700,
        InvalidRequest = -32600,
        MethodNotFound = -32601,
        InvalidParams = -32602,
        InternalError = -32603,
        /// <summary>
        /// 这是JSON-RPC保留错误码的起始范围。它并不表示真正的错误代码。
        /// 起始和结束范围之间不能定义LSP错误码。为了向后兼容，
        /// ' ServerNotInitialized '和' UnknownErrorCode '留在范围内。
        /// </summary>
        ServerErrorStart = -32099,
        /// <summary>
        /// 这是JSON-RPC保留错误码的结束范围。它并不表示真正的错误代码。
        /// </summary>
        ServerErrorEnd = -32000,
        /// <summary>
        /// 错误代码，表明服务器在接收到“初始化”请求之前收到了通知或请求。
        /// </summary>
        ServerNotInitialized = -32002,
        UnknownErrorCode = -32001,
        /// <summary>
        /// LSP保留错误码的起始范围。它并不表示真正的错误代码。
        /// </summary>
        lspReservedErrorRangeStart = -32899,
        /// <summary>
        /// 请求失败，但语法正确，例如方法名称已知且参数有效。
        /// 错误消息应包含有关请求失败原因的人类可读信息。
        /// </summary>
        RequestFailed = -32803,
        /// <summary>
        /// 服务器取消了请求。此错误代码应仅用于明确支持服务器可取消的请求。
        /// </summary>
        ServerCancelled = -32802,
        /// <summary>
        /// 服务器检测到文档的内容在正常情况下被修改。如果服务器检测到未处理消息中的内容更改，
        /// 则不应发送此错误代码。即使是在较旧的状态下计算的结果也可能对客户端有用。
        /// </summary>
        ContentModified = -32801,
        /// <summary>
        /// 客户端已经取消了一个请求，服务器已经检测到这个取消。
        /// </summary>
        RequestCancelled = -32800,
        /// <summary>
        /// LSP保留错误码的结束范围。它并不表示真正的错误代码。
        /// </summary>
        ReservedErrorRangeEnd = -32800,
    }
}
