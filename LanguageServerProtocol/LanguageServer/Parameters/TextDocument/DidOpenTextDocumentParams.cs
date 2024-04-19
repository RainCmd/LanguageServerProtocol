namespace LanguageServer.Parameters.TextDocument
{
    public class DidOpenTextDocumentParams(TextDocumentItem textDocument)
    {
        public TextDocumentItem textDocument = textDocument;
    }
}
