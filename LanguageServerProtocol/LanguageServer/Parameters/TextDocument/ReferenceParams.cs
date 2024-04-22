namespace LanguageServer.Parameters.TextDocument
{
    public class ReferenceParams(TextDocumentIdentifier textDocument, Position position) : TextDocumentPositionParams(textDocument, position)
    {
        public ReferenceContext? context;
    }
}
