namespace LanguageServer.Parameters.TextDocument
{
    /// <summary>
    /// For <c>textDocument/publishDiagnostics</c>
    /// </summary>
    public class PublishDiagnosticsParams
    {
        /// <summary>
        /// 报告诊断信息的URI。
        /// </summary>
        public Uri? uri;

        /// <summary>
        /// 诊断信息项的数组。
        /// </summary>
        public Diagnostic[]? diagnostics;
    }
}
