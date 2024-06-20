namespace LanguageServer.Parameters.General
{
    /// <summary>
    /// For <c>initialize</c>
    /// </summary>
    /// <seealso>Spec 3.9.0</seealso>
    public class CompletionItemCapabilities
    {
        /// <summary>
        /// Client supports snippets as insert text.
        /// </summary>
        /// <remarks>
        /// A snippet can define tab stops and placeholders with <c>$1</c>, <c>$2</c>
        /// and <c>${3:foo}</c>. <c>$0</c> defines the final tab stop, it defaults to
        /// the end of the snippet. Placeholders with equal identifiers are linked,
        /// that is typing in one will update others too.
        /// </remarks>
        public bool? snippetSupport;

        /// <summary>
        /// 客户端支持在补全项上提交字符。
        /// </summary>
        /// <seealso>Spec 3.2.0</seealso>
        public bool? commitCharactersSupport;

        /// <summary>
        /// Client supports the follow content formats for the documentation
        /// property.The order describes the preferred format of the client.
        /// 客户端支持文档属性的以下内容格式。订单描述了客户端的首选格式。
        /// </summary>
        /// <value>
        /// See <see cref="LanguageServer.Parameters.MarkupKind"/> for an enumeration of standardized kinds.
        /// </value>
        /// <seealso>Spec 3.3.0</seealso>
        /// <seealso cref="LanguageServer.Parameters.MarkupKind"/>
        public string[]? documentationFormat;

        /// <summary>
        /// 客户端支持完成项上弃用的属性。
        /// </summary>
        /// <seealso>Spec 3.7.2</seealso>
        public bool? deprecatedSupport;

        /// <summary>
        /// 客户端支持完成项上的预选属性。
        /// </summary>
        /// <seealso>Spec 3.9.0</seealso>
        public bool? preselectSupport;

        /// <summary>
        /// 客户端支持完成项上的标记属性。支持标记的客户端必须优雅地处理未知标记。
        /// 在resolve调用中将完成项发送回服务器时，客户端尤其需要保留未知标记。
        /// </summary>
        public CompletionSupportTags? tagSupport;

        /// <summary>
        /// 客户端支持插入替换编辑，以控制在文本中插入补全项或应该替换文本时的不同行为。
        /// </summary>
        public bool? insertReplaceSupport;

        /// <summary>
        /// 指示客户端可以在完成项上惰性解析哪些属性。在3.16.0版本之前，
        /// 只有预定义的属性' documentation '和' detail '可以被惰性解析。
        /// </summary>
        public ResolveSupport? resolveSupport;

        /// <summary>
        /// 客户端支持在完成项上使用' insertTextMode '属性来覆盖客户端定义的空白处理模式(参见' insertTextMode ')。
        /// </summary>
        public InsertTextModeSupport? insertTextModeSupport;

        /// <summary>
        /// 客户端支持完成项标签详细信息(参见' CompletionItemLabelDetails ')。
        /// </summary>
        public bool? labelDetailsSupport;
    }
}
