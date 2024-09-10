namespace LanguageServer.Parameters.TextDocument
{
    /// <summary>
    /// 通过表达式求值提供内联值。
    /// 如果只指定了一个范围，则将从基础文档中提取表达式。
    /// 可选表达式可用于覆盖提取的表达式。
    /// @since 3.17.0
    /// </summary>
    public class InlineValueEvaluatableExpression(Range range)
    {
        /// <summary>
        /// 应用内联值的文档范围。
        /// 该范围用于从基础文档中提取可求值表达式。
        /// </summary>
        public Range range = range;

        /// <summary>
        /// 如果指定，则表达式将覆盖提取的表达式。
        /// </summary>
        public string? expression;
    }
}
