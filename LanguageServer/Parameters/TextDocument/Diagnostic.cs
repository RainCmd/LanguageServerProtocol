using LanguageServer.Json;

namespace LanguageServer.Parameters.TextDocument
{
	/// <summary>
	/// For <c>textDocument/codeAction</c> and <c>textDocument/publishDiagnostics</c>
	/// </summary>
	/// <seealso>Spec 3.7.0</seealso>
	public class Diagnostic(Range range, string message)
    {
        /// <summary>
        /// 消息适用的范围。
        /// </summary>
        public Range range = range;

        /// <summary>
        /// 诊断的严重性。可以省略。
        /// </summary>
        /// <remarks>
        /// 如果省略，则由客户端将诊断解释为错误、警告、信息或提示。
        /// </remarks>
        public DiagnosticSeverity? severity;

        /// <summary>
        /// 诊断代码。可以省略。
        /// </summary>
        public NumberOrString? code;

        /// <summary>
        /// 描述错误代码的可选属性。要求代码字段<see cref="code"/>不为空。
        /// </summary>
        public CodeDescription? codeDescription;

        /// <summary>
        /// 一个人类可读的字符串，描述这个诊断的来源，
        /// 例如 typescript 或 super lint。
        /// 它通常出现在用户界面中。
        /// </summary>
        public string? source;

		/// <summary>
		/// The diagnostic's message.
		/// </summary>
		public string message = message;

        /// <summary>
        /// 关于诊断的其他元数据。
        /// </summary>
        public DiagnosticTag[]? tags;

        /// <summary>
        /// 一组相关的诊断信息。
        /// </summary>
        /// <remarks>
        /// 例如，当作用域中的符号名发生冲突时，可以通过此属性标记所有定义。
        /// </remarks>
        /// <seealso>Spec 3.7.0</seealso>
        public DiagnosticRelatedInformation[]? relatedInformation;
    }
}
