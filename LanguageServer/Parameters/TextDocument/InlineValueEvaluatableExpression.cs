﻿namespace LanguageServer.Parameters.TextDocument
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
        /// The document range for which the inline value applies.
        /// The range is used to extract the evaluatable expression from the underlying document.
        /// </summary>
        Range range = range;

        /// <summary>
        /// If specified the expression overrides the extracted expression.
        /// </summary>
        string? expression;
    }
}