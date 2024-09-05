namespace LanguageServer.Parameters.TextDocument
{
    /// <summary>
    /// Provide inline value as text.
    /// @since 3.17.0
    /// </summary>
    /// <param name="range"></param>
    /// <param name="text"></param>
    public class InlineValueText(Range range, string text)
    {
        /// <summary>
        /// The document range for which the inline value applies.
        /// </summary>
        public Range range = range;
        /// <summary>
        /// The text of the inline value.
        /// </summary>
        public string text = text;
    }
}
