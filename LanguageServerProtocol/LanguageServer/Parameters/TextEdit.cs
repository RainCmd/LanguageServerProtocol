namespace LanguageServer.Parameters
{
    /// <summary>
    /// For <c>textDocument/willSaveWaitUntil</c>,
    /// <c>textDocument/completion</c>,
    /// <c>textDocument/formatting</c>,
    /// <c>textDocument/rangeFormatting</c>,
    /// <c>textDocument/onTypeFormatting</c>,
    /// <c>textDocument/rename</c>, and
    /// <c>workspace/applyEdit</c>
    /// </summary>
    public class TextEdit(Range range, string newText)
    {
        /// <summary>
        /// 要操作的文本文档的范围。要在文档中插入文本，请创建start === end的范围。
        /// </summary>
        public Range range = range;
        /// <summary>
        /// 要插入的字符串。对于删除操作，使用空字符串。
        /// </summary>
        public string newText = newText;
    }
}
