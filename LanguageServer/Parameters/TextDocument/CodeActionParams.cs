namespace LanguageServer.Parameters.TextDocument
{
    /// <summary>
    /// For <c>textDocument/codeAction</c>
    /// </summary>
    /// <remarks>
    /// Params for the CodeActionRequest
    /// </remarks>
    public class CodeActionParams(TextDocumentIdentifier textDocument, Range range, CodeActionContext context)
    {
        /// <summary>
        /// The document in which the command was invoked.
        /// </summary>
        public TextDocumentIdentifier textDocument = textDocument;

        /// <summary>
        /// The range for which the command was invoked.
        /// </summary>
        public Range range = range;

        /// <summary>
        /// Context carrying additional information.
        /// </summary>
        public CodeActionContext context = context;
    }
}
