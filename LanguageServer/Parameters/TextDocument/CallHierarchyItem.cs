namespace LanguageServer.Parameters.TextDocument
{
    public class CallHierarchyItem(string name, SymbolKind kind, DocumentUri uri, Range range, Range selectionRange)
    {
        /// <summary>
        /// The name of this item.
        /// </summary>
        public string name = name;
        /// <summary>
        /// The kind of this item.
        /// </summary>
        public SymbolKind kind = kind;
        /// <summary>
        /// Tags for this item.
        /// </summary>
        public SymbolTag[]? tags;
        /// <summary>
        /// 此项目的更多细节，例如函数的签名。
        /// </summary>
        public string? detail;
        /// <summary>
        /// The resource identifier of this item.
        /// </summary>
        public DocumentUri uri = uri;
        /// <summary>
        /// 包含该符号的范围不包括前后空格，但包括其他所有内容，例如注释和代码。
        /// </summary>
        public Range range = range;
        /// <summary>
        /// 当选择该符号时应该选择和显示的范围，例如函数的名称。必须包含在<see cref="range"/>中
        /// </summary>
        public Range selectionRange = selectionRange;
        /// <summary>
        /// A data entry field that is preserved between a call hierarchy prepare and
        /// incoming calls or outgoing calls requests.
        /// </summary>
        public dynamic? data;
    }
}
