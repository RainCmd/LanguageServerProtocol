namespace LanguageServer.Parameters.TextDocument
{
    public enum InsertTextFormat
    {
        /// <summary>
        /// 要插入的主要文本被视为普通字符串。
        /// </summary>
        PlainText = 1,
        /// <summary>
        /// 要插入的主要文本被视为一个片段。
        /// 代码片段可以用' $1 '，' $2 '和' ${3:foo} '来定义制表符和占位符。' $0 '定义了最后的制表符，
        /// 它默认位于代码段的末尾。具有相同标识符的占位符被链接，也就是说输入一个也会更新其他的。
        /// </summary>
        Snippet = 2,
    }
}
