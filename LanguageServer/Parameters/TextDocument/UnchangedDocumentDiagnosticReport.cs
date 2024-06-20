namespace LanguageServer.Parameters.TextDocument
{
    public class UnchangedDocumentDiagnosticReport(string resultId)
    {
        /// <summary>
        /// 一个文档诊断报告，表明对最后的结果没有更改。如果提供了结果id，服务器只能返回' unchanged '
        /// </summary>
        public readonly string kind = DocumentDiagnosticReportKind.Unchanged;
        /// <summary>
        /// 结果id，将在同一文档的下一个诊断请求时发送。
        /// </summary>
        public readonly string resultId = resultId;
    }
}
