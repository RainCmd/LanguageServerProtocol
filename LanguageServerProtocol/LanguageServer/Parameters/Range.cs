namespace LanguageServer.Parameters
{
    /// <summary>
    /// For <c>textDocument/didChange</c>,
    /// <c>textDocument/willSaveWaitUntil</c>,
    /// <c>textDocument/completion</c>,
    /// <c>textDocument/hover</c>,
    /// <c>textDocument/references</c>,
    /// <c>textDocument/documentHighlight</c>,
    /// <c>textDocument/formatting</c>,
    /// <c>textDocument/rangeFormatting</c>,
    /// <c>textDocument/codeAction</c>,
    /// <c>textDocument/codeLens</c>,
    /// <c>textDocument/documentLink</c>,
    /// <c>textDocument/publishDiagnostics</c>,
    /// <c>documentLink/resolve</c>,
    /// <c>workspace/applyEdit</c>, and
    /// <c>workspace/symbol</c>
    /// </summary>
    /// <remarks>
    /// 表示为(从零开始的)开始和结束位置的文本文档中的范围。范围相当于编辑器中的选择。因此，结束位置是排他的。
    /// </remarks>
    public class Range(Position start, Position end)
    {
        public Position start = start;
        public Position end = end;
    }
}