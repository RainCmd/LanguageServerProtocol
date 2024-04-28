namespace LanguageServer.Parameters.TextDocument
{
    public class DocumentFormattingParams(TextDocumentIdentifier textDocument, FormattingOptions options)
    {
        public TextDocumentIdentifier textDocument = textDocument;

        public FormattingOptions options = options;
    }
}
