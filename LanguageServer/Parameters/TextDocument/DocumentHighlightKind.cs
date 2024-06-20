namespace LanguageServer.Parameters.TextDocument
{
    /// <summary>
    /// 文档高亮类。
    /// </summary>
    public enum DocumentHighlightKind
    {
        /// <summary>
        /// 文本事件。
        /// </summary>
        Text = 1,
        /// <summary>
        /// 符号的读访问，如读变量。
        /// </summary>
        Read = 2,
        /// <summary>
        /// 对符号的写访问，如对变量的写。
        /// </summary>
        Write = 3,
    }
}
