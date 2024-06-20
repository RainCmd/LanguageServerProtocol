namespace LanguageServer.Parameters.General
{
    public class WindowClientCapabilities
    {
        /// <summary>
        /// 它指示客户端是否支持使用' window/workDoneProgress/create '请求的服务器启动进度。
        /// 
        /// 该功能还控制客户端是否支持处理进度通知。如果设置服务器允许在请求特定的服务器功能中报告' workDoneProgress '属性
        /// </summary>
        public bool? workDoneProgress;

        /// <summary>
        /// 特定于showMessage请求的功能
        /// </summary>
        public ShowMessageRequestClientCapabilities? showMessage;

        /// <summary>
        /// 显示文档请求的客户机功能。
        /// </summary>
        public ShowDocumentClientCapabilities? showDocument;
    }
}