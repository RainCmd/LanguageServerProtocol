namespace LanguageServer.Parameters.TextDocument
{
    public class CallHierarchyPrepareParams(TextDocumentIdentifier textDocument, Position position)
    {
        public TextDocumentIdentifier textDocument = textDocument;
        public Position position = position;
    }
}
