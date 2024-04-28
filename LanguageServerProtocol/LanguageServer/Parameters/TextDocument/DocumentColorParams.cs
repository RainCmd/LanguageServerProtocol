namespace LanguageServer.Parameters.TextDocument
{
    /// <summary>
    /// For <c>textDocument/documentColor</c>
    /// </summary>
    /// <seealso>Spec 3.6.0</seealso>
    public class DocumentColorParams(TextDocumentIdentifier textDocument)
    {
        /// <summary>
        /// The text document.
        /// </summary>
        /// <seealso>Spec 3.6.0</seealso>
        public TextDocumentIdentifier textDocument = textDocument;
    }
}
