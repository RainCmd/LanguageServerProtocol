namespace LanguageServer.Parameters.General
{
    /// <summary>
    /// 完成项标记是额外的注释，用于调整完成项的呈现。
    /// </summary>
    public static class CompletionItemTag
    {
        /// <summary>
        /// Render a completion as obsolete, usually using a strike-out.
        /// 通常用三击出局法使完成的动作失效。
        /// </summary>
        public const int Deprecated = 1;
    }
}
