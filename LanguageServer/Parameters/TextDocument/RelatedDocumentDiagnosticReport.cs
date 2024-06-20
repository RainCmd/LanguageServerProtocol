using LanguageServer.Json;

namespace LanguageServer.Parameters.TextDocument
{
    /// <summary>
    /// <see cref="FullDocumentDiagnosticReport"/> | <see cref="UnchangedDocumentDiagnosticReport"/>
    /// </summary>
    public class RelatedDocumentDiagnosticReport : Either<FullDocumentDiagnosticReport, UnchangedDocumentDiagnosticReport>
    {
        public RelatedDocumentDiagnosticReport(FullDocumentDiagnosticReport value) : base(value) { }
        public RelatedDocumentDiagnosticReport(UnchangedDocumentDiagnosticReport value) : base(value) { }
        public static implicit operator RelatedDocumentDiagnosticReport(FullDocumentDiagnosticReport value) => new(value);
        public static implicit operator RelatedDocumentDiagnosticReport(UnchangedDocumentDiagnosticReport value) => new(value);
    }
}
