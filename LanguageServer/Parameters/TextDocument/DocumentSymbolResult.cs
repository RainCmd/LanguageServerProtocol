using LanguageServer.Json;

namespace LanguageServer.Parameters.TextDocument
{
    /// <summary>
    /// For <c>textDocument/documentSymbol</c>
    /// </summary>
    /// <remarks>
    /// <see cref="DocumentSymbol"/>[] | <see cref="SymbolInformation"/>[]
    /// </remarks>
    /// <seealso>Spec 3.10.0</seealso>
    public class DocumentSymbolResult : Either<DocumentSymbol[], SymbolInformation[]>
    {
        /// <summary>
        /// Initializes a new instance of <c>DocumentSymbolResult</c> with the specified value.
        /// </summary>
        /// <param name="value"></param>
        /// <seealso>Spec 3.10.0</seealso>
        public DocumentSymbolResult(DocumentSymbol[] value) : base(value) { }

        /// <summary>
        /// Initializes a new instance of <c>DocumentSymbolResult</c> with the specified value.
        /// </summary>
        /// <param name="value"></param>
        /// <seealso>Spec 3.10.0</seealso>
        public DocumentSymbolResult(SymbolInformation[] value) : base(value) { }
        public static implicit operator DocumentSymbolResult(DocumentSymbol[] value) => new(value);
        public static implicit operator DocumentSymbolResult(SymbolInformation[] value) => new(value);
    }
}
