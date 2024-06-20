namespace LanguageServer.Parameters.General
{
    /// <summary>
    /// For <c>initialize</c>
    /// </summary>
    public class ClientCapabilities
    {
        /// <summary>
        /// 特定于工作空间的客户端功能。
        /// </summary>
        public WorkspaceClientCapabilities? workspace;

        /// <summary>
        /// 文本文档特定的客户端功能。
        /// </summary>
        public TextDocumentClientCapabilities? textDocument;

        /// <summary>
        /// 一般客户端功能。
        /// </summary>
        public GeneralClientCapabilities? general;

        /// <summary>
        /// 特定于窗口的客户端功能。
        /// </summary>
        public WindowClientCapabilities? window;

        /// <summary>
        /// 特定于笔记本文档支持的功能。
        /// </summary>
        public NotebookDocumentClientCapabilities? notebookDocument;

        /// <summary>
        /// 实验性客户端功能。
        /// </summary>
        public dynamic? experimental;
    }
}
