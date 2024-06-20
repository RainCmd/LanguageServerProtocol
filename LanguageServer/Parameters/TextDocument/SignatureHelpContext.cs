namespace LanguageServer.Parameters.TextDocument
{
    /// <summary>
    /// 关于触发签名帮助请求的上下文的其他信息。
    /// </summary>
    public class SignatureHelpContext
    {
        /// <summary>
        /// 触发签名帮助的操作。
        /// </summary>
        public SignatureHelpTriggerKind triggerKind;
        /// <summary>
        /// 触发签名帮助的字符。
        /// 
        /// This is undefined when triggerKind !== SignatureHelpTriggerKind. TriggerCharacter
        /// </summary>
        public string? triggerCharacter;

        /// <summary>
        /// 如果签名帮助在触发时已经显示，则为true。
        /// 
        /// 当签名帮助已经处于活动状态时，会发生重新触发，
        /// 并可能由输入触发器字符、移动光标或更改文档内容等操作引起。
        /// </summary>
        public bool isRetrigger;

        /// <summary>
        /// 当前活动的“SignatureHelp”。
        /// 
        /// activeSignatureHelp有它的SignatureHelp。
        /// 根据用户在可用签名中导航而更新的activeSignature字段。
        /// </summary>
        public SignatureHelp? activeSignatureHelp;
    }
}
