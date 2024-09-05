namespace LanguageServer.Parameters.TextDocument
{
    /// <summary>
    /// A parameter literal used in inline value requests.
    /// @since 3.17.0
    /// </summary>
    public class InlineValueParams(TextDocumentIdentifier textDocument, Range range, InlineValueContext context)
    {
        /// <summary>
        /// The text document.
        /// </summary>
        public TextDocumentIdentifier textDocument = textDocument;
        /// <summary>
        /// The document range for which inline values should be computed.
        /// </summary>
        public Range range = range;
        /// <summary>
        /// Additional information about the context in which inline values were requested.
        /// </summary>
        public InlineValueContext context = context;
    }
}
