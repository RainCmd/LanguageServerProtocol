namespace LanguageServer.Parameters.TextDocument
{
    public class DocumentSymbolParams(TextDocumentIdentifier textDocument)
    {
        public TextDocumentIdentifier textDocument = textDocument;
    }
}
