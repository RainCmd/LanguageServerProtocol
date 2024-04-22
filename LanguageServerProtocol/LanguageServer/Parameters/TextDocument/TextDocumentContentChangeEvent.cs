using LanguageServer.Json;

namespace LanguageServer.Parameters.TextDocument
{
    /// <summary>
    /// <see cref="TextDocumentContentChange"/>或<see cref="TextDocumentContentWhole"/>
    /// </summary>
    public class TextDocumentContentChangeEvent : Either
    {
        public static implicit operator TextDocumentContentChangeEvent(TextDocumentContentChange change) => new(change);
        public static implicit operator TextDocumentContentChangeEvent(TextDocumentContentWhole whole) => new(whole);
        public bool IsChange => Type == typeof(TextDocumentContentChange);
        public bool IsWhole => Type == typeof(TextDocumentContentWhole);
        public TextDocumentContentChange Change => GetValue<TextDocumentContentChange>();
        public TextDocumentContentWhole Whole => GetValue<TextDocumentContentWhole>();
        public TextDocumentContentChangeEvent(TextDocumentContentChange value) : base(value, typeof(TextDocumentContentChange)) { }
        public TextDocumentContentChangeEvent(TextDocumentContentWhole value) : base(value, typeof(TextDocumentContentWhole)) { }
    }
}