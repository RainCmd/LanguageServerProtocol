using LanguageServer.Json;

namespace LanguageServer.Parameters.TextDocument
{
    /// <summary>
    /// For <c>textDocument/signatureHelp</c>,
    /// <c>textDocument/completion</c>, and
    /// <c>completionItem/resolve</c>
    /// </summary>
    /// <remarks>
    /// 一个人类可读的字符串，表示文档注释。
    /// <see cref="string"/> | <see cref="TextDocument.MarkupContent"/>
    /// </remarks>
    /// <seealso>Spec 3.3.0</seealso>
    public class Documentation : Either<string, MarkupContent>
    {
        /// <summary>
        /// Initializes a new instance of <c>CompletionItemDocumentation</c> with the specified value.
        /// </summary>
        /// <param name="value"></param>
        /// <seealso>Spec 3.3.0</seealso>
        public Documentation(string value) : base(value) { }

        /// <summary>
        /// Initializes a new instance of <c>CompletionItemDocumentation</c> with the specified value.
        /// </summary>
        /// <param name="value"></param>
        /// <seealso>Spec 3.3.0</seealso>
        public Documentation(MarkupContent value) : base(value) { }
        public static implicit operator Documentation(string value) => new(value);
        public static implicit operator Documentation(MarkupContent value) => new(value);
    }
}
