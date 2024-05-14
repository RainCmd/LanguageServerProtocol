namespace LanguageServer.Parameters.TextDocument
{
    /// <summary>
    /// For <c>textDocument/signatureHelp</c>
    /// </summary>
    /// <remarks>
    /// 表示可调用签名的参数。
    /// 参数可以有一个标签和一个文档注释。
    /// </remarks>
    /// <seealso>Spec 3.3.0</seealso>
    public class ParameterInformation(string label)
    {
        /// <summary>
        /// The label of this parameter.
        /// </summary>
        /// <remarks>
        /// Will be shown in the UI.
        /// </remarks>
        public string label = label;

        /// <summary>
        /// 这个参数的可读文档注释。
        /// </summary>
        /// <remarks>
        /// 将显示在UI中，但可以省略。
        /// </remarks>
        /// <seealso>Spec 3.3.0</seealso>
        public Documentation? documentation;
    }
}
