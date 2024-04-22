namespace LanguageServer.Parameters
{
    /// <summary>
    /// For <c>textDocument/didChange</c>,
    /// <c>textDocument/willSaveWaitUntil</c>,
    /// <c>textDocument/completion</c>,
    /// <c>textDocument/hover</c>,
    /// <c>textDocument/signatureHelp</c>,
    /// <c>textDocument/references</c>,
    /// <c>textDocument/documentHighlight</c>,
    /// <c>textDocument/formatting</c>,
    /// <c>textDocument/rangeFormatting</c>,
    /// <c>textDocument/onTypeFormatting</c>,
    /// <c>textDocument/definition</c>,
    /// <c>textDocument/codeAction</c>,
    /// <c>textDocument/codeLens</c>,
    /// <c>textDocument/documentLink</c>,
    /// <c>textDocument/rename</c>,
    /// <c>textDocument/publishDiagnostics</c>,
    /// <c>documentLink/resolve</c>,
    /// <c>workspace/applyEdit</c>, and
    /// <c>workspace/symbol</c>
    /// </summary>
    public class Position(long line, long character)
    {
        /// <summary>
        /// 文档的行号，从0开始
        /// </summary>
        public long line = line;
        /// <summary>
        /// Character offset on a line in a document (zero-based). The meaning of this offset is determined by the negotiated `PositionEncodingKind`.
        /// </summary>
        /// <remarks>
        /// 文档中一行上的字符偏移量(从零开始)。这个偏移量的含义由协商的<see cref="General.PositionEncodingKind"/>决定。
        /// 如果字符值大于行长度，则默认返回行长度。
        /// </remarks>
        public long character = character;
    }
}