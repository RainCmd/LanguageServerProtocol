namespace LanguageServer.Parameters.TextDocument
{
    /// <summary>
    /// For <c>textDocument/completion</c>
    /// </summary>
    /// <seealso>Spec 3.3.0</seealso>
    public class CompletionParams : TextDocumentPositionParams
    {
        /// <summary>
        /// 完成上下文。
        /// </summary>
        /// <remarks>
        /// 这只在客户端指定使用 ClientCapabilities.textDocument.completion.contextSupport === true 有效
        /// </remarks>/remarks>
        /// <seealso>Spec 3.3.0</seealso>
        public CompletionContext? context;
    }
}
