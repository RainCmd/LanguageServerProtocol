namespace LanguageServer.Parameters.TextDocument
{
    public class DidSaveTextDocumentParams(TextDocumentIdentifier textDocument, string text)
    {
        public TextDocumentIdentifier textDocument = textDocument;

        /// <summary>
        /// 保存时可选的内容。取决于请求保存通知时的includeText值。
        /// </summary>
        public string text = text;
    }
}
