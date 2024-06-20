namespace LanguageServer.Parameters.TextDocument
{
    /// <summary>
    /// A diagnostic report indicating that the last returned report is still accurate.
    /// </summary>
    public class FullDocumentDiagnosticReport(string? resultId, Diagnostic[] items)
    {
        /// <summary>
        /// A full document diagnostic report.
        /// </summary>
        public readonly string kind = DocumentDiagnosticReportKind.Full;
        /// <summary>
        /// 可选的结果id。如果提供，它将在同一文档的下一次诊断请求中发送。
        /// </summary>
        public readonly string? resultId = resultId;
        public readonly Diagnostic[] items = items;
    }
}
