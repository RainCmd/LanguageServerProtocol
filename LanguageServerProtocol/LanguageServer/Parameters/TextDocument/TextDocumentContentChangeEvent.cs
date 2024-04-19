namespace LanguageServer.Parameters.TextDocument
{
    public class TextDocumentContentChangeEvent(Range range, long rangeLength, string text)
    {
        public Range range = range;

        public long rangeLength = rangeLength;

        public string text = text;
    }
}