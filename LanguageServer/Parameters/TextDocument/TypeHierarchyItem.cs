namespace LanguageServer.Parameters.TextDocument
{
    public class TypeHierarchyItem(string name, SymbolKind kind, DocumentUri uri, Range range, Range selectionRange)
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
        /// More detail for this item, e.g. the signature of a function.
        /// </summary>
        public string? detail;
        /// <summary>
        /// The resource identifier of this item.
        /// </summary>
        public DocumentUri uri = uri;
        /// <summary>
        /// The range enclosing this symbol not including leading/trailing whitespace
        /// but everything else, e.g. comments and code.
        /// </summary>
        public Range range = range;
        /// <summary>
        /// The range that should be selected and revealed when this symbol is being
        /// picked, e.g. the name of a function. Must be contained by the <see cref="range"/>
        /// </summary>
        public Range selectionRange = selectionRange;
        /// <summary>
        /// A data entry field that is preserved between a type hierarchy prepare and
        /// supertypes or subtypes requests. It could also be used to identify the
        /// type hierarchy in the server, helping improve the performance on
        /// resolving supertypes and subtypes.
        /// </summary>
        public dynamic? data;
    }
}
