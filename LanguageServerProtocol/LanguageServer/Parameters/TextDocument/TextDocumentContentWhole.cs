namespace LanguageServer.Parameters.TextDocument
{
    /// <summary>
    /// 整个文档的新文本
    /// </summary>
    /// <param name="text"></param>
    public class TextDocumentContentWhole(string text)
    {
        public string text = text;
    }
}
