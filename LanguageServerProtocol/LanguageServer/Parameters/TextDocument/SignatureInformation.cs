namespace LanguageServer.Parameters.TextDocument
{
    /// <summary>
    /// For <c>textDocument/signatureHelp</c>
    /// </summary>
    /// <remarks>
    /// 表示可调用对象的签名。
    /// 一个签名可以有一个标签(如函数名)、一个文档注释和一组参数。
    /// </remarks>
    /// <seealso>Spec 3.3.0</seealso>
    public class SignatureInformation
    {
        /// <summary>
        /// 这个签名的标签。
        /// </summary>
        /// <remarks>
        /// Will be shown in the UI.
        /// </remarks>
        public string? label;

        /// <summary>
        /// The human-readable doc-comment of this parameter.
        /// </summary>
        /// <remarks>
        /// 将显示在UI中，但可以省略。
        /// </remarks>
        /// <seealso>Spec 3.3.0</seealso>
        public Documentation? documentation;

        /// <summary>
        /// 该签名的参数。
        /// </summary>
        public ParameterInformation[]? parameters;
    }
}
