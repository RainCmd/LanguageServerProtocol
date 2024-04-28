namespace LanguageServer.Parameters.TextDocument
{
    public class RenameParams(TextDocumentIdentifier textDocument, Position position, string newName) : TextDocumentPositionParams(textDocument, position)
    {
        public string newName = newName;
    }
}
