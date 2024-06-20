namespace LanguageServer.Parameters.TextDocument
{
    /// <summary>
    /// For <c>textDocument/willSave</c>
    /// </summary>
    public class WillSaveTextDocumentParams(TextDocumentIdentifier textDocument, TextDocumentSaveReason reason)
    {
        public TextDocumentIdentifier textDocument = textDocument;

        public TextDocumentSaveReason reason = reason;
    }
}
