namespace LanguageServer.Parameters.TextDocument
{
    public class DocumentRangeFormattingParams(TextDocumentIdentifier textDocument, Range range, FormattingOptions options)
    {
        public TextDocumentIdentifier textDocument = textDocument;

        public Range range = range;

        public FormattingOptions options = options;
    }
}
