using LanguageServer.Json;

namespace LanguageServer.Parameters.TextDocument
{
    /// <summary>
    /// <see cref="InsertReplaceEdit"/> | <see cref="TextEdit"/>
    /// </summary>
    public class TextEditOrInsertReplaceEdit : Either<InsertReplaceEdit, TextEdit>
    {
        public TextEditOrInsertReplaceEdit(InsertReplaceEdit value) : base(value) { }
        public TextEditOrInsertReplaceEdit(TextEdit value) : base(value) { }
        public static implicit operator TextEditOrInsertReplaceEdit(InsertReplaceEdit value) => new(value);
        public static implicit operator TextEditOrInsertReplaceEdit(TextEdit value) => new(value);
    }
}
