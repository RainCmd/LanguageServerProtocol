namespace LanguageServer.Parameters.TextDocument
{
    /// <summary>
    /// A parameter literal used in inlay hint requests.
    /// @since 3.17.0
    /// </summary>
    public class InlayHintParams(TextDocumentIdentifier textDocument, Range range)
    {
        /// <summary>
        /// The text document.
        /// </summary>
        public TextDocumentIdentifier textDocument = textDocument;
        /// <summary>
        /// The visible document range for which inlay hints should be computed.
        /// </summary>
        public Range range = range;
    }
}
