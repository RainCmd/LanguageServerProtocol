namespace LanguageServer.Parameters.TextDocument
{
    /// <summary>
    /// The diagnostic tags.
    /// </summary>
    public enum DiagnosticTag
    {
        /// <summary>
        /// 未使用或不必要的代码。
        /// 客户端被允许用这个标签来呈现诊断，而不是用一个错误的歪歪扭扭。
        /// </summary>
        Unnecessary = 1,
        /// <summary>
        /// 废弃或过时的代码。
        /// 允许客户端使用此标记来呈现诊断。
        /// </summary>
        Deprecated = 2
    }
}
