namespace LanguageServer.Parameters.TextDocument
{
    public class TextDocumentPositionParams(TextDocumentIdentifier textDocument, Position position)
    {
        public TextDocumentIdentifier textDocument = textDocument;

        public Position position = position;
    }
}
