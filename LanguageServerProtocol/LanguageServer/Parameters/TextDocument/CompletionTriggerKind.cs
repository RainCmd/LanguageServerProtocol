namespace LanguageServer.Parameters.TextDocument
{
    /// <summary>
    /// 如何触发完成
    /// </summary>
    /// <seealso>Spec 3.3.0</seealso>
    public enum CompletionTriggerKind
    {
        /// <summary>
        /// 通过输入标识符(24x7代码完成)、手动调用(例如Ctrl+Space)或通过API触发完成。
        /// </summary>
        /// <seealso>Spec 3.3.0</seealso>
        Invoked = 1,
        /// <summary>
        /// 完成是由 CompletionRegistrationOptions 的 triggerCharacters 属性指定的触发字符触发的。
        /// </summary>
        /// <seealso>Spec 3.3.0</seealso>
        TriggerCharacter = 2,
        /// <summary>
        /// 由于当前完成列表不完整，重新触发了完成。
        /// </summary>
        /// <seealso>Spec 3.6.0</seealso>
        TriggerForIncompleteCompletions = 3,
    }
}
