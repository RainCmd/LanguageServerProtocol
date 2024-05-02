using LanguageServer.Parameters.Window;

namespace LanguageServer.Client
{
    /// <summary>
    /// 用于发送与窗口相关的消息的代理类。
    /// </summary>
    public sealed class WindowProxy(Proxy proxy)
    {
        /// <summary>
        /// window/showMessage
        /// 通知从服务器发送到客户端，要求客户端在用户界面中显示特定的消息。
        /// </summary>
        public void ShowMessage(ShowMessageParams param)
        {
            proxy.SendNotification("window/showMessage", param);
        }

        /// <summary>
        /// window/showMessageRequest
        /// 请求从服务器发送到客户端，请求客户端在用户界面中显示特定的消息。
        /// </summary>
        /// <returns></returns>
        public Task<MessageActionItem> ShowMessageRequest(ShowMessageRequestParams param)
        {
            return proxy.SendRequest<ShowMessageRequestParams, MessageActionItem>("window/showMessageRequest", param);
        }

        /// <summary>
        /// window/logMessage
        /// 通知从服务器发送到客户端，要求客户端记录特定的消息。
        /// </summary>
        public void LogMessage(LogMessageParams param)
        {
            proxy.SendNotification("window/logMessage", param);
        }

        /// <summary>
        /// telemetry/event
        /// 通知从服务器发送到客户端，要求客户端记录遥测事件。
        /// </summary>
        public void Event(dynamic param)
        {
            proxy.SendNotification("telemetry/event", param);
        }
    }
}
