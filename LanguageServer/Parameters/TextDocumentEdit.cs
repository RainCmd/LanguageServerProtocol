namespace LanguageServer.Parameters
{
    /// <summary>
    /// For <c>textDocument/rename</c> and <c>workspace/applyEdit</c>
    /// </summary>
    public class TextDocumentEdit(VersionedTextDocumentIdentifier textDocument, TextEdit[] edits)
    {
        public VersionedTextDocumentIdentifier textDocument = textDocument;

        public TextEdit[] edits = edits;
    }
}
