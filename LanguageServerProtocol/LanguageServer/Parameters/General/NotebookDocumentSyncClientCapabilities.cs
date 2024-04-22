namespace LanguageServer.Parameters.General
{
    /// <summary>
    /// 特定于笔记本的客户机功能。
    /// </summary>
    public class NotebookDocumentSyncClientCapabilities
    {
        /// <summary>
        /// 实现是否支持动态注册。如果设置为“true”，则客户端支持新的“(NotebookDocumentSyncRegistrationOptions & NotebookDocumentSyncOptions)”返回值，用于相应的服务器功能。
        /// </summary>
        public bool? dynamicRegistration;
        /// <summary>
        /// 客户端支持发送每个单元的执行汇总数据。
        /// </summary>
        public bool? executionSummarySupport;
    }
}