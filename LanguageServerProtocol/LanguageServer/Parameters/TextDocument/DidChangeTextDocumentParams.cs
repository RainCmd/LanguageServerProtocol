namespace LanguageServer.Parameters.TextDocument
{
    /// <summary>
    /// For <c>textDocument/didChange</c>
    /// </summary>
    public class DidChangeTextDocumentParams(VersionedTextDocumentIdentifier textDocument, TextDocumentContentChangeEvent[] contentChanges)
    {
        public VersionedTextDocumentIdentifier textDocument = textDocument;
        /// <summary>
        /// The actual content changes. The content changes describe single state
        /// changes to the document. So if there are two content changes c1 (at
        /// array index 0) and c2 (at array index 1) for a document in state S then
        /// c1 moves the document from S to S' and c2 from S' to S''. So c1 is
        /// computed on the state S and c2 is computed on the state S'.
        /// </summary>
        /// <remarks>
        /// 数组的后一个变化是建立在前一个变化的基础之上的
        /// </remarks>

        public TextDocumentContentChangeEvent[] contentChanges = contentChanges;
    }
}
