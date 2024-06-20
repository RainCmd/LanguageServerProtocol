namespace LanguageServer.Parameters.General
{
    public class CompletionListCapabilities
    {
        /// <summary>
        /// 客户端在完成列表中支持以下itemDefaults。
        /// 
        /// The value lists the supported property names of the
        /// `CompletionList.itemDefaults` object. If omitted
        /// no properties are supported.
        /// </summary>
        public string[]? itemDefaults;
    }
}