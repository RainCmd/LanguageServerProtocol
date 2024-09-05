namespace LanguageServer.Parameters.TextDocument
{
    /// <summary>
    /// 通过变量查找提供内联值。
    /// 如果只指定了一个范围，则将从基础文档中提取变量名。
    /// 可选的变量名可用于覆盖提取的名称。
    /// 
    ///  @since 3.17.0
    /// </summary>
    /// <param name="range"></param>
    /// <param name="caseSensitiveLookup"></param>
    public class InlineValueVariableLookup(Range range, bool caseSensitiveLookup)
    {
        /// <summary>
        /// The document range for which the inline value applies.
        /// The range is used to extract the variable name from the underlying document.
        /// </summary>
        public Range range = range;
        /// <summary>
        /// If specified the name of the variable to look up.
        /// </summary>
        public string? variableName;
        /// <summary>
        /// How to perform the lookup.
        /// </summary>
        public bool caseSensitiveLookup = caseSensitiveLookup;
    }
}
