namespace LanguageServer.Parameters.General
{
    /// <summary>
    /// 显示消息请求客户机功能
    /// </summary>
    public class ShowMessageRequestClientCapabilities
    {
        /// <summary>
        /// 特定于' MessageActionItem '类型的功能。
        /// </summary>
        public MessageActionItemCapabilities? messageActionItem;
    }
}