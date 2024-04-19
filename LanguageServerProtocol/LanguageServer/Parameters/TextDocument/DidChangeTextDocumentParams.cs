namespace LanguageServer.Parameters.TextDocument
{
    /// <summary>
    /// For <c>textDocument/didChange</c>
    /// </summary>
    public class DidChangeTextDocumentParams(VersionedTextDocumentIdentifier textDocument, TextDocumentContentChangeEvent[] contentChanges)
    {
        public VersionedTextDocumentIdentifier textDocument = textDocument;

        public TextDocumentContentChangeEvent[] contentChanges = contentChanges;
    }
}
