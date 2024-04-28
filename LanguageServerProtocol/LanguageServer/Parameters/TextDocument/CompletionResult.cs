using LanguageServer.Json;

namespace LanguageServer.Parameters.TextDocument
{
    /// <summary>
    /// For <c>textDocument/completion</c>
    /// </summary>
    /// <remarks>
    /// <see cref="CompletionItem"/>[] | <see cref="CompletionList"/>
    /// </remarks>
    public class CompletionResult : Either<CompletionItem[], CompletionList>
    {
        /// <summary>
        /// Initializes a new instance of <c>CompletionResult</c> with the specified value.
        /// </summary>
        /// <param name="value"></param>
        public CompletionResult(CompletionItem[] value) : base(value) { }

        /// <summary>
        /// Initializes a new instance of <c>CompletionResult</c> with the specified value.
        /// </summary>
        /// <param name="value"></param>
        public CompletionResult(CompletionList value) : base(value) { }
        public static implicit operator CompletionResult(CompletionItem[] value) => new(value);
        public static implicit operator CompletionResult(CompletionList value) => new(value);
    }
}
