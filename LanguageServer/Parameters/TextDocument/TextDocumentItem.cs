namespace LanguageServer.Parameters.TextDocument
{
    public class TextDocumentItem(DocumentUri uri, string languageId, long version, string text)
    {
        public DocumentUri uri = uri;

        public string languageId = languageId;

        public long version = version;

        public string text = text;
    }
}
