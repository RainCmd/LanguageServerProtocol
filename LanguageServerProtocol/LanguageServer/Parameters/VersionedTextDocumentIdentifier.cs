
namespace LanguageServer.Parameters
{
    /// <summary>
    /// For <c>textDocument/rename</c>,
    /// <c>textDocument/didChange</c>, and
    /// <c>workspace/applyEdit</c>
    /// </summary>
    public class VersionedTextDocumentIdentifier(DocumentUri uri, long version) : TextDocumentIdentifier(uri)
    {
        public long version = version;
    }
}