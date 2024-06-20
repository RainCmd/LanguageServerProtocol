namespace LanguageServer.Parameters.TextDocument
{
    /// <summary>
    /// 如何触发签名帮助。
    /// </summary>
    public enum SignatureHelpTriggerKind
    {
        /// <summary>
        /// 由用户或命令手动调用签名帮助。
        /// </summary>
        Invoked = 1,
        /// <summary>
        /// 签名帮助被触发字符触发。
        /// </summary>
        TriggerCharacter = 2,
        /// <summary>
        /// 由光标移动或文档内容更改触发签名帮助。
        /// </summary>
        ContentChange = 3
    }
}
