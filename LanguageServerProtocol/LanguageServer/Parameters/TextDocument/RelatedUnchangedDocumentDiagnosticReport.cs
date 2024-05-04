namespace LanguageServer.Parameters.TextDocument
{
    public class RelatedUnchangedDocumentDiagnosticReport(string resultId, Dictionary<DocumentUri, RelatedDocumentDiagnosticReport>? relatedDocuments) : UnchangedDocumentDiagnosticReport(resultId)
    {
        public readonly Dictionary<DocumentUri, RelatedDocumentDiagnosticReport>? relatedDocuments = relatedDocuments;
    }
}
