using LanguageServer.Json;

namespace LanguageServer.Parameters.TextDocument
{
    /// <summary>
    /// Inline value information can be provided by different means:
    /// - directly as a text value (class InlineValueText).
    /// - as a name to use for a variable lookup (class InlineValueVariableLookup)
    /// - as an evaluatable expression (class InlineValueEvaluatableExpression)
    /// The InlineValue types combines all inline value types into one type.
    /// </summary>
    /// <remarks>
    /// <see cref="InlineValueText"/> | <see cref="InlineValueVariableLookup"/> | <see cref="InlineValueEvaluatableExpression"/>
    /// </remarks>
    /// <seealso>Spec 3.17.0</seealso>
    public class InlineValueResult : Either<InlineValueText, InlineValueVariableLookup, InlineValueEvaluatableExpression>
    {
        public InlineValueResult(InlineValueText inlineValue) : base(inlineValue) { }
        public InlineValueResult(InlineValueVariableLookup inlineValue) : base(inlineValue) { }
        public InlineValueResult(InlineValueEvaluatableExpression inlineValue) : base(inlineValue) { }

        public static implicit operator InlineValueResult(InlineValueText value) => new(value);
        public static implicit operator InlineValueResult(InlineValueVariableLookup value) => new(value);
        public static implicit operator InlineValueResult(InlineValueEvaluatableExpression value) => new(value);
    }
}
