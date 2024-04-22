namespace LanguageServer.Parameters.TextDocument
{
    /// <summary>
    /// 文档文本变化的部分
    /// </summary>
    /// <param name="range"></param>
    /// <param name="rangeLength"></param>
    /// <param name="text"></param>
    public class TextDocumentContentChange(Range range, string text)
    {
        public Range range = range;

        public long? rangeLength;

        public string text = text;
    }
}
