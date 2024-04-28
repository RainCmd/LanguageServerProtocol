namespace LanguageServer.Parameters.TextDocument
{
    public class CodeLensParams(TextDocumentIdentifier textDocument)
    {
        public TextDocumentIdentifier textDocument = textDocument;
    }
}
