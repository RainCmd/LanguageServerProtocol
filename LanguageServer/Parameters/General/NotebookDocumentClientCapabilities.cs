namespace LanguageServer.Parameters.General
{
    /// <summary>
    /// 特定于笔记本文档支持的功能。
    /// </summary>
    public class NotebookDocumentClientCapabilities(NotebookDocumentSyncClientCapabilities synchronization)
    {
        /// <summary>
        /// 特定于笔记本文档同步的功能
        /// </summary>
        public NotebookDocumentSyncClientCapabilities synchronization = synchronization;
    }
}