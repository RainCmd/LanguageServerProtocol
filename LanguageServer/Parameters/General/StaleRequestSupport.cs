namespace LanguageServer.Parameters.General
{
    public class StaleRequestSupport(bool cancel, string[] retryOnContentModified)
    {
        /// <summary>
        /// 客户端将主动取消请求。
        /// </summary>
        public bool cancel = cancel;
        /// <summary>
        /// 如果客户端收到错误码为“ContentModified”的响应，客户端将重试该请求的请求列表。
        /// </summary>
        public readonly string[] retryOnContentModified = retryOnContentModified;
    }
}