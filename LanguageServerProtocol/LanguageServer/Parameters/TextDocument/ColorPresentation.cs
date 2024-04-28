namespace LanguageServer.Parameters.TextDocument
{
    /// <summary>
    /// For <c>textDocument/colorPresentation</c>
    /// </summary>
    /// <seealso>Spec 3.6.0</seealso>
    public class ColorPresentation(string label)
    {
        /// <summary>
        /// 这个颜色展示的标签。它将显示在颜色选择器标题上。
        /// </summary>
        /// <remarks>
        /// 默认情况下，这也是在选择这种颜色表示时插入的文本。
        /// </remarks>
        /// <seealso>Spec 3.6.0</seealso>
        public string label = label;

        /// <summary>
        /// 当选择该颜色的表示时应用于文档的一种<see cref="TextEdit">编辑</see>。
        /// </summary>
        /// <remarks>
        /// When <c>falsy</c> the <see cref="label"/> is used.
        /// </remarks>
        /// <seealso>Spec 3.6.0</seealso>
        public TextEdit? textEdit;

        /// <summary>
        /// 一个可选的附加<see cref="TextEdit">文本编辑</see>数组，在选择此颜色表示时应用。
        /// </summary>
        /// <remarks>
        /// 编辑不能与<see cref="textEdit">主编辑</see>重叠，也不能与编辑本身重叠。
        /// </remarks>
        /// <seealso>Spec 3.6.0</seealso>
        public TextEdit[]? additionalTextEdits;
    }
}
