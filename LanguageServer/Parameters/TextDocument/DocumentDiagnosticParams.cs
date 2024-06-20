namespace LanguageServer.Parameters.TextDocument
{
    public class DocumentDiagnosticParams(TextDocumentIdentifier textDocument)
    {
        public readonly TextDocumentIdentifier textDocument = textDocument;
        /// <summary>
        /// 注册期间提供的附加标识符。
        /// </summary>
        public readonly string? identifier;
        /// <summary>
        /// The result id of a previous response if provided.
        /// </summary>
        public readonly string? previousResultId;
    }
}
