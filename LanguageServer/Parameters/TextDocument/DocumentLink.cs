namespace LanguageServer.Parameters.TextDocument
{
    /// <summary>
    /// 文档链接是文本文档中链接到内部或外部资源(如另一个文本文档或web站点)的范围。
    /// </summary>
    public class DocumentLink(Range range)
    {
        /// <summary>
        /// 此链接适用的范围。
        /// </summary>
        public Range range = range;

        /// <summary>
        /// 这个链接指向的uri。如果缺少解析请求，则稍后发送解析请求。
        /// </summary>
        public DocumentUri? target;
        /// <summary>
        /// 将鼠标悬停在此链接上时的工具提示文本。
        /// </summary>
        /// <remarks>
        /// 如果提供了工具提示，它将以字符串形式显示，其中包括如何触发链接的说明
        /// ，例如“{0}(ctrl + click)”。具体说明因操作系统、用户设置和本地化而异。
        /// </remarks>
        public string? tooltip;

        /// <summary>
        /// 保存在DocumentLinkRequest和DocumentLinkResolveRequest之间的文档链接上的数据输入字段。
        /// </summary>
        public dynamic? data;
    }
}
