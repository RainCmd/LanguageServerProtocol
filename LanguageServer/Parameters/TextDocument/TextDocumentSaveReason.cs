namespace LanguageServer.Parameters.TextDocument
{
    /// <summary>
    /// 表示保存文本文档的原因。
    /// </summary>
    public enum TextDocumentSaveReason
    {
        /// <summary>
        /// 手动触发，例如，由用户按下保存，通过启动调试，或通过API调用。
        /// </summary>
        Manual = 1,
        /// <summary>
        /// 延迟后自动。
        /// </summary>
        AfterDelay = 2,
        /// <summary>
        /// 当编辑失去焦点时。
        /// </summary>
        FocusOut = 3,
    }
}