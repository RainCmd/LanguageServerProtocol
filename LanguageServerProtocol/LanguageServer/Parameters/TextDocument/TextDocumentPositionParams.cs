namespace LanguageServer.Parameters.TextDocument
{
    /// <summary>
    /// 在请求中用于传递文本文档和该文档中的位置的参数字面量。
    /// 在发出对文本文档的请求时，由客户端决定如何将选择转换为位置。
    /// 例如，客户端可以尊重或忽略选择方向，使LSP请求与内部实现的特性保持一致。
    /// </summary>
    /// <param name="textDocument"></param>
    /// <param name="position"></param>
    public class TextDocumentPositionParams(TextDocumentIdentifier textDocument, Position position)
    {
        public TextDocumentIdentifier textDocument = textDocument;

        public Position position = position;
    }
}
