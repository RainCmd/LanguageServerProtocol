using LanguageServer.Json;

namespace LanguageServer.Parameters.TextDocument
{
    public class ReferenceParams(TextDocumentIdentifier textDocument, Position position, ReferenceContext context) : TextDocumentPositionParams(textDocument, position)
    {
        public ReferenceContext context = context;
        /// <summary>
        /// 应该来自<see href="https://microsoft.github.io/language-server-protocol/specifications/lsp/3.17/specification/#partialResultParams">PartialResultParams</see> 的值，
        /// 但是由于不支持多继承，所以直接放在这里了<br/>
        /// 一个可选的令牌，服务器可以使用它向客户端报告部分结果(例如流)。
        /// </summary>
        public NumberOrString? partialResultToken;
    }
}
