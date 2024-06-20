namespace LanguageServer.Parameters.General
{
    public class GeneralClientCapabilities
    {
        /// <summary>
        /// 表明客户端如何处理过时请求的客户端功能(例如，由于信息过时，客户端将不再处理响应的请求)。
        /// </summary>
        public StaleRequestSupport? staleRequestSupport;
        /// <summary>
        /// 特定于正则表达式的客户端功能。
        /// </summary>
        public RegularExpressionsClientCapabilities? regularExpressions;
        /// <summary>
        /// 特定于客户端降价解析器的客户端功能。
        /// </summary>
        public MarkdownClientCapabilities? markdown;
        /// <summary>
        /// <see cref="PositionEncodingKind"/>
        /// </summary>
        /// <remarks>
        /// 客户端支持的位置编码。客户端和服务器必须同意相同的位置编码，
        /// 以确保偏移量(例如:在一行中的字符位置在两边被解释为相同。
        /// 
        /// 为了保持协议向后兼容，以下应用:如果位置编码数组中缺少值'utf-16'，
        /// 服务器可以假设客户端支持utf-16。因此，UTF-16是一种强制编码。
        /// 
        /// 如果省略，默认为['utf-16']。
        /// 
        /// 实现注意事项:由于从一种编码转换为另一种编码需要文件/行内容，因此转换最好在读取文件的地方完成，通常在服务器端。
        /// </remarks>
        public string[]? positionEncodings;
    }
}
