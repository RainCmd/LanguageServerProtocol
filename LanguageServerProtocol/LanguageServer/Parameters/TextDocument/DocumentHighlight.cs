namespace LanguageServer.Parameters.TextDocument
{
    /// <summary>
    /// 文档高亮显示是文本文档中的一个值得特别注意的区域。
    /// 通常，通过更改其范围的背景颜色来实现文档高亮显示。
    /// </summary>
    /// <param name="range"></param>
    public class DocumentHighlight(Range range)
    {
        public Range range = range;

        public DocumentHighlightKind? kind;
    }
}
