namespace LanguageServer.Parameters.TextDocument
{
    /// <summary>
    /// Represents a folding range.
    /// For <c>textDocument/foldingRange</c>
    /// </summary>
    /// <seealso>Spec 3.10.0</seealso>
    public class FoldingRange
    {
        /// <summary>
        /// The zero-based line number from where the folded range starts.
        /// </summary>
        /// <remarks>
        /// 为了有效，末尾必须为零或大于或小于文档中的行数。
        /// </remarks>
        /// <seealso>Spec 3.10.0</seealso>
        public long startLine;

        /// <summary>
        /// The zero-based character offset from where the folded range starts.
        /// </summary>
        /// <remarks>
        /// 如果未定义，则默认为起始行长度。
        /// </remarks>
        /// <seealso>Spec 3.10.0</seealso>
        public long? startCharacter;

        /// <summary>
        /// The zero-based line number where the folded range ends.
        /// </summary>
        /// <remarks>
        /// 折叠区域以该行的最后一个字符结束。为了有效，末尾必须为零或大于或小于文档中的行数。
        /// </remarks>
        /// <seealso>Spec 3.10.0</seealso>
        public long endLine;

        /// <summary>
        /// The zero-based character offset before the folded range ends.
        /// </summary>
        /// <remarks>
        /// 如果未定义，则默认为结束行的长度。
        /// </remarks>
        /// <seealso>Spec 3.10.0</seealso>
        public long? endCharacter;

        /// <summary>
        /// Describes the kind of the folding range such as <c>comment</c> or <c>region</c>.
        /// </summary>
        /// <remarks>
        /// 描述折叠范围的类型，如“注释”或“区域”。该类型用于对折叠范围进行分类，
        /// 并用于“折叠所有注释”等命令。
        /// </remarks>
        /// <value>
        /// See <see cref="FoldingRangeKind"/> for an enumeration of standardized kinds.
        /// </value>
        /// <seealso>Spec 3.10.0</seealso>
        /// <seealso cref="FoldingRangeKind"/>
        public string? kind;

        /// <summary>
        /// 客户端在折叠指定范围时应显示的文本。如果客户端未定义或不支持，则客户端将选择默认值。
        /// </summary>
        public string? collapsedText;
    }
}
