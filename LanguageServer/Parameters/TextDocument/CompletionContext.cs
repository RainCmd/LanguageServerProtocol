namespace LanguageServer.Parameters.TextDocument
{
    /// <summary>
    /// For <c>textDocument/completion</c>
    /// </summary>
    /// <remarks>
    /// 包含有关触发完成请求的上下文的附加信息。
    /// </remarks>
    /// <seealso>Spec 3.3.0</seealso>
    public class CompletionContext
    {
        /// <summary>
        /// 如何触发完成。
        /// </summary>
        /// <seealso>Spec 3.3.0</seealso>
        public CompletionTriggerKind triggerKind;

        /// <summary>
        /// 具有完整触发代码的触发字符(单个字符)。
        /// Is undefined if <c>triggerKind !== CompletionTriggerKind.TriggerCharacter</c>
        /// </summary>
        /// <seealso>Spec 3.3.0</seealso>
        public string? triggerCharacter;
    }
}
