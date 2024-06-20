namespace LanguageServer.Parameters.TextDocument
{
    /// <summary>
    /// 结构来捕获错误代码的描述。
    /// </summary>
    public class CodeDescription(DocumentUri href)
    {
        /// <summary>
        /// 要打开的URI，其中包含有关诊断错误的更多信息。
        /// </summary>
        public DocumentUri href = href;
    }
}
