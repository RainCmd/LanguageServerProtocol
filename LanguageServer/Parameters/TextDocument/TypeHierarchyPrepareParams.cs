namespace LanguageServer.Parameters.TextDocument
{
    public class TypeHierarchyPrepareParams(TextDocumentIdentifier textDocument, Position position)
    {
        public TextDocumentIdentifier textDocument = textDocument;
        public Position position = position;
    }
}
