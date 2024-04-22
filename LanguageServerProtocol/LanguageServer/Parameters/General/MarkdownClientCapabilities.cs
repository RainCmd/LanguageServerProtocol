namespace LanguageServer.Parameters.General
{
    /// <summary>
    /// 特定于所使用的markdown解析器的客户机功能。
    /// </summary>
    public class MarkdownClientCapabilities(string parser, string? version, string[]? allowedTags)
    {
        /// <summary>
        /// The name of the parser.
        /// </summary>
        public readonly string parser = parser;
        public readonly string? version = version;
        /// <summary>
        /// 客户端在Markdown中允许/支持的HTML标记列表。
        /// </summary>
        public readonly string[]? allowedTags = allowedTags;
    }
}