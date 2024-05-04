using LanguageServer.Json;

namespace LanguageServer.Parameters.TextDocument
{
    /// <summary>
    /// 文档诊断拉取请求的结果。报告可以是包含所请求文档的所有诊断的完整报告，
    /// 也可以是未更改的报告，表明与上次拉取请求相比，诊断没有任何更改。
    /// </summary>
    /// <remarks>
    /// <see cref="RelatedFullDocumentDiagnosticReport"/> | <see cref="RelatedUnchangedDocumentDiagnosticReport"/>
    /// </remarks>
    public class DocumentDiagnosticReport : Either<RelatedFullDocumentDiagnosticReport, RelatedUnchangedDocumentDiagnosticReport>
    {
        public DocumentDiagnosticReport(RelatedFullDocumentDiagnosticReport value) : base(value) { }
        public DocumentDiagnosticReport(RelatedUnchangedDocumentDiagnosticReport value) : base(value) { }
        public static implicit operator DocumentDiagnosticReport(RelatedFullDocumentDiagnosticReport value) => new (value);
        public static implicit operator DocumentDiagnosticReport(RelatedUnchangedDocumentDiagnosticReport value) => new (value);
    }
}
