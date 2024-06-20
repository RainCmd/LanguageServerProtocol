namespace LanguageServer.Parameters.TextDocument
{
    /// <summary>
    /// For <c>textDocument/colorPresentation</c>
    /// </summary>
    /// <seealso>Spec 3.6.0</seealso>
    public class ColorPresentationParams(TextDocumentIdentifier textDocument, Color color, Range range)
    {
        /// <summary>
        /// The text document.
        /// </summary>
        /// <seealso>Spec 3.6.0</seealso>
        public TextDocumentIdentifier textDocument = textDocument;

        /// <summary>
        /// 要求展示的颜色信息。
        /// </summary>
        /// <remarks>
        /// The property's name was originally <c>colorInfo</c>, and it has been changed to <c>color</c> since the spec 3.8.0.
        /// </remarks>
        /// <seealso>Spec 3.6.0</seealso>
        public Color color = color;

        /// <summary>
        /// 要插入颜色的范围。作为上下文。
        /// </summary>
        /// <seealso>Spec 3.6.0</seealso>
        public Range range = range;
    }
}
