namespace LanguageServer.Parameters.TextDocument
{
    /// <summary>
    /// 完成项标签的附加详细信息。
    /// </summary>
    public class CompletionItemLabelDetails
    {
        /// <summary>
        /// 一个可选的字符串，在<see cref="CompletionItem.label"/>之后不太显眼，
        /// 不带任何空格。应该用于函数签名或类型注释。
        /// </summary>
        public string? detail;
        /// <summary>
        /// 一个可选的字符串，在<see cref="detail"/>之后不太显眼地呈现。应用于完全限定名称或文件路径。
        /// </summary>
        public string? description;
    }
}