namespace LanguageServer.Parameters.TextDocument
{
    public class DocumentOnTypeFormattingParams(TextDocumentIdentifier textDocument, Position position, string ch, FormattingOptions options)
    {
        public TextDocumentIdentifier textDocument = textDocument;

        /// <summary>
        /// on type formatting应该发生的位置。
        /// 这并不一定是属性' ch '表示的字符输入的确切位置。
        /// </summary>
        public Position position = position;

        /// <summary>
        /// 在类型请求时触发格式化的已键入字符。
        /// 这并不一定是插入到文档中的最后一个字符，
        /// 因为客户端也可以自动插入字符(例如，自动大括号补全)。
        /// </summary>
        public string ch = ch;

        public FormattingOptions options = options;
    }
}
