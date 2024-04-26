namespace LanguageServer.Parameters.General
{
    public class DiagnosticOptions(bool interFileDependencies, bool workspaceDiagnostics)
    {
        /// <summary>
        /// 一个可选的标识符，客户端在其下管理诊断。
        /// </summary>
        public string? identifier;
        /// <summary>
        /// 语言是否具有文件间依赖关系，这意味着在一个文件中编辑代码可能导致在另一个文件中使用不同的诊断集。
        /// 文件间依赖关系对于大多数编程语言来说都很常见，而对于编译器来说则不常见。
        /// </summary>
        public bool interFileDependencies = interFileDependencies;
        /// <summary>
        /// 服务器还提供对工作空间诊断的支持。
        /// </summary>
        public bool workspaceDiagnostics = workspaceDiagnostics;
    }
}
