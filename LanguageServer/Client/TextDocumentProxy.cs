using LanguageServer.Parameters.TextDocument;

namespace LanguageServer.Client
{
    /// <summary>
    /// 用于发送与文本文档相关的消息的代理类。
    /// </summary>
    public class TextDocumentProxy(Proxy proxy)
    {
        /// <summary>
        /// textDocument/publishDiagnostics
        /// 通知从服务器发送到客户端，以表示验证运行的结果。
        /// </summary>
        /// <param name="param"></param>
        public void PublishDiagnostics(PublishDiagnosticsParams param)
        {
            proxy.SendNotification("textDocument/publishDiagnostics", param);
        }
    }
}
