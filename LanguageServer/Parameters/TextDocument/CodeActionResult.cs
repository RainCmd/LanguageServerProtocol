using LanguageServer.Json;

namespace LanguageServer.Parameters.TextDocument
{
    /// <summary>
    /// For <c>textDocument/codeAction</c>
    /// </summary>
    /// <remarks>
    /// <see cref="Command"/>[] | <see cref="CodeAction"/>[]
    /// </remarks>
    /// <seealso>Spec 3.8.0</seealso>
    public class CodeActionResult : Either<Command[], CodeAction[]>
    {

        /// <summary>
        /// Initializes a new instance of <c>CodeActionResult</c> with the specified value.
        /// </summary>
        /// <param name="value"></param>
        /// <seealso>Spec 3.8.0</seealso>
        public CodeActionResult(Command[] value) : base(value) { }

        /// <summary>
        /// Initializes a new instance of <c>CodeActionResult</c> with the specified value.
        /// </summary>
        /// <param name="value"></param>
        /// <seealso>Spec 3.8.0</seealso>
        public CodeActionResult(CodeAction[] value) : base(value) { }
        public static implicit operator CodeActionResult(Command[] value) => new(value);
        public static implicit operator CodeActionResult(CodeAction[] value) => new(value);
    }
}
