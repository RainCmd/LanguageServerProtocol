namespace LanguageServer.Parameters.TextDocument
{
    public class TextDocumentItem(Uri uri, string languageId, long version, string text)
    {
        public Uri uri = uri;

        public string languageId = languageId;

        public long version = version;

        public string text = text;
    }
}
