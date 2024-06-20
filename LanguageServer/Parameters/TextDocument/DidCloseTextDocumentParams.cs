namespace LanguageServer.Parameters.TextDocument
{
    public class DidCloseTextDocumentParams(TextDocumentIdentifier textDocument)
    {
        public TextDocumentIdentifier textDocument = textDocument;
    }
}
