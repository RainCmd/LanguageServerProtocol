namespace LanguageServer.Parameters.TextDocument
{
    public class RelatedFullDocumentDiagnosticReport(string? resultId, Diagnostic[] items, Dictionary<DocumentUri, RelatedDocumentDiagnosticReport>? relatedDocuments) : FullDocumentDiagnosticReport(resultId, items)
    {
        public readonly Dictionary<DocumentUri, RelatedDocumentDiagnosticReport>? relatedDocuments = relatedDocuments;
    }
}
