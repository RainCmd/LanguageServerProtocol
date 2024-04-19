namespace LanguageServer.Parameters.General
{
    /// <summary>
    /// For <c>initialize</c>
    /// </summary>
    public class ClientCapabilities(WorkspaceClientCapabilities workspace, TextDocumentClientCapabilities textDocument)
    {
        /// <summary>
        /// 特定于工作空间的客户端功能。
        /// </summary>
        public WorkspaceClientCapabilities workspace = workspace;

        /// <summary>
        /// 文本文档特定的客户端功能。
        /// </summary>
        public TextDocumentClientCapabilities textDocument = textDocument;

        //看vscode发过来的json里还有 window，general，notebookDocument 这几个，不知道干嘛用的

        /// <summary>
        /// 实验性客户端功能。
        /// </summary>
        public dynamic? experimental;
    }
}
