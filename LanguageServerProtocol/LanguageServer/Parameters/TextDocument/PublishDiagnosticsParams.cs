namespace LanguageServer.Parameters.TextDocument
{
    /// <summary>
    /// For <c>textDocument/publishDiagnostics</c>
    /// </summary>
    public class PublishDiagnosticsParams(Uri uri, Diagnostic[] diagnostics)
    {
        /// <summary>
        /// 报告诊断信息的URI。
        /// </summary>
        public readonly Uri uri = uri;

        /// <summary>
        /// 可选发布诊断的文档的版本号。
        /// </summary>
        public int? version;

        /// <summary>
        /// 诊断信息项的数组。
        /// </summary>
        public readonly Diagnostic[] diagnostics = diagnostics;
    }
}
