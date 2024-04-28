namespace LanguageServer.Parameters.TextDocument
{
    /// <summary>
    /// For <c>textDocument/documentColor</c>
    /// </summary>
    /// <seealso>Spec 3.6.0</seealso>
    public class ColorInformation(Range range, Color color)
    {
        /// <summary>
        /// 该颜色在文档中显示的范围。
        /// </summary>
        /// <seealso>Spec 3.6.0</seealso>
        public Range range = range;

        /// <summary>
        ///此颜色范围的实际颜色值。
        /// </summary>
        /// <seealso>Spec 3.6.0</seealso>
        public Color color = color;
    }
}
