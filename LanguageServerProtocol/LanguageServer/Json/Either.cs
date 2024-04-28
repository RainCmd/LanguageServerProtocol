namespace LanguageServer.Json
{
    /// <summary>
    /// Mimic discriminated union types
    /// </summary>
    /// <remarks>
    /// <see cref="Serializer"/> must support these derived types below:
    /// 必须支持下列派生类型:
    /// <list type="bullet">
    /// <item><see cref="Parameters.General.ChangeNotificationsOptions"/></item>
    /// <item><see cref="Parameters.TextDocument.CodeActionResult"/></item>
    /// <item><see cref="Parameters.General.ColorProviderOptionsOrBoolean"/></item>
    /// <item><see cref="Parameters.TextDocument.CompletionResult"/></item>
    /// <item><see cref="Parameters.General.DiagnosticOptionsOrProviderOptions"/></item>
    /// <item><see cref="Parameters.TextDocument.Documentation"/></item>
    /// <item><see cref="Parameters.TextDocument.DocumentSymbolResult"/></item>
    /// <item><see cref="Parameters.General.FoldingRangeProviderOptionsOrBoolean"/></item>
    /// <item><see cref="Parameters.TextDocument.HoverContents"/></item>
    /// <item><see cref="Parameters.LocationSingleOrArray"/></item>
    /// <item><see cref="NumberOrString"/></item>
    /// <item><see cref="Parameters.General.ProviderOptionsOrBoolean"/></item>
    /// <item><see cref="Parameters.TextDocument.TextDocumentContentChangeEvent"/></item>
    /// <item><see cref="Parameters.General.TextDocumentSync"/></item>
    /// </list>
    /// </remarks>
    public abstract class Either(object value, Type type)
    {
        public object Value => value;
        public Type Type => type;
        public T GetValue<T>()
        {
            ArgumentNullException.ThrowIfNull(type);
            ArgumentNullException.ThrowIfNull(value);
            return type == typeof(T) ? (T)value : throw new InvalidOperationException();
        }
    }
}
