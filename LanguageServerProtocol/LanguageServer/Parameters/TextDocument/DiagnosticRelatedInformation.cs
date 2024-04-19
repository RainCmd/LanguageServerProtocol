namespace LanguageServer.Parameters.TextDocument
{
    /// <summary>
    /// 表示诊断的相关消息和源代码位置。
    /// For <c>textDocument/codeAction</c> and <c>textDocument/publishDiagnostics</c>
    /// </summary>
    /// <remarks>
    /// 这应该用于指向导致诊断或与诊断相关的代码位置，例如在作用域中复制符号时。
    /// </remarks>
    /// <seealso>Spec 3.7.0</seealso>
    public class DiagnosticRelatedInformation(Location location, string message)
    {
        /// <summary>
        /// 此相关诊断信息的位置。
        /// </summary>
        /// <seealso>Spec 3.7.0</seealso>
        public Location location = location;

        /// <summary>
        /// 此相关诊断信息的消息。
        /// </summary>
        /// <seealso>Spec 3.7.0</seealso>
        public string message = message;
    }
}
