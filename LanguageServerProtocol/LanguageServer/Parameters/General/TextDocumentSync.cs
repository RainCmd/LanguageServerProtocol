using LanguageServer.Json;

namespace LanguageServer.Parameters.General
{
    /// <summary>
    /// For <c>initialize</c><br/>
    /// <see cref="TextDocumentSyncKind"/> | <see cref="TextDocumentSyncOptions"/>
    /// </summary>
    public class TextDocumentSync : Either<TextDocumentSyncKind, TextDocumentSyncOptions>
    {
        /// <summary>
        /// Initializes a new instance of <c>TextDocumentSync</c> with the specified value.
        /// </summary>
        /// <param name="value"></param>
        public TextDocumentSync(TextDocumentSyncKind value) : base(value) { }

        /// <summary>
        /// Initializes a new instance of <c>TextDocumentSync</c>  with the specified value.
        /// </summary>
        public TextDocumentSync(TextDocumentSyncOptions value) : base(value) { }

        public static implicit operator TextDocumentSync(TextDocumentSyncKind value) => new(value);
        public static implicit operator TextDocumentSync(TextDocumentSyncOptions value) => new(value);
    }
}
