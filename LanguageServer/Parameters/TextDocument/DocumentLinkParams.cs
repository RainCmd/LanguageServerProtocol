namespace LanguageServer.Parameters.TextDocument
{
    public class DocumentLinkParams(TextDocumentIdentifier textDocument)
    {
        public TextDocumentIdentifier textDocument = textDocument;
    }
}
