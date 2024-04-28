using LanguageServer.Json;

namespace LanguageServer.Parameters.TextDocument
{
    /// <summary>
    /// <see cref="TextDocumentContentChange"/>或<see cref="TextDocumentContentWhole"/>
    /// </summary>
    public class TextDocumentContentChangeEvent : Either<TextDocumentContentChange, TextDocumentContentWhole>
    {
        public TextDocumentContentChangeEvent(TextDocumentContentChange value) : base(value) { }
        public TextDocumentContentChangeEvent(TextDocumentContentWhole value) : base(value) { }
        public static implicit operator TextDocumentContentChangeEvent(TextDocumentContentChange change) => new(change);
        public static implicit operator TextDocumentContentChangeEvent(TextDocumentContentWhole whole) => new(whole);
    }
}