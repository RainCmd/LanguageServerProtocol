namespace LanguageServer.Parameters
{
    /// <summary>
    /// 提供插入和替换操作的特殊文本编辑。
    /// </summary>
    public class InsertReplaceEdit(string newText, Range insert, Range replace)
    {
        /// <summary>
        /// 要插入的字符串。
        /// </summary>
        public string newText = newText;
        /// <summary>
        /// 如果请求插入时的范围
        /// </summary>
        public Range insert = insert;
        /// <summary>
        /// 请求替换时的范围。
        /// </summary>
        public Range replace = replace;
    }
}
