namespace LanguageServer.Parameters.TextDocument
{
    /// <summary>
    /// For <c>textDocument/signatureHelp</c>
    /// </summary>
    public class SignatureHelp
    {
        /// <summary>
        /// One or more signatures.
        /// </summary>
        public SignatureInformation[]? signatures;

        /// <summary>
        /// 主签名。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 如果省略或该值在签名范围之外，则该值默认为零，
        /// 如果signatures.length=== 0则忽略该值。
        /// 只要有可能，实现者应该对活动签名做出积极的决定，而不应该依赖于默认值。
        /// </para>
        /// <para>
        /// 在协议的未来版本中，为了更好地表达这一点，该属性可能会成为强制性的。
        /// </para>
        /// </remarks>
        public int? activeSignature;

        /// <summary>
        /// 主签名的激活参数。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 如果主签名有参数，如果省略或该值超出signatures[activeSignature].parameters的范围默认为0。如果没有参数，则忽略主签名。
        /// </para>
        /// <para>
        /// 在协议的未来版本中，如果活动签名确实有活动参数，
        /// 则该属性可能会成为强制性的，以便更好地表达活动参数。
        /// </para>
        /// </remarks>
        public int? activeParameter;
    }
}
