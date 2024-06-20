namespace LanguageServer.Parameters.General
{
    /// <summary>
    /// For <c>initialize</c>
    /// </summary>
    /// <seealso>Spec 3.4.0</seealso>
    public class WorkspaceClientCapabilities
    {
        /// <summary>
        /// 客户端通过支持请求 workspace/applyEdit 来支持对工作空间应用批量编辑
        /// </summary>
        public bool applyEdit;

        /// <summary>
        /// 特定于 WorkspaceEdit 的功能
        /// </summary>
        public EditCapabilities? workspaceEdit;

        /// <summary>
        /// 特定于 workspace/didChangeConfiguration 通知的功能。
        /// </summary>
        public RegistrationCapabilities? didChangeConfiguration;

        /// <summary>
        /// 特定于 workspace/didChangeWatchedFiles 通知的功能。
        /// </summary>
        public RegistrationCapabilities? didChangeWatchedFiles;

        /// <summary>
        /// 特定于 workspace/symbol 请求的功能。
        /// </summary>
        /// <seealso>Spec 3.4.0</seealso>
        public SymbolCapabilities? symbol;

        /// <summary>
        /// 特定于 workspace/executeCommand 请求的功能。
        /// </summary>
        public RegistrationCapabilities? executeCommand;

        /// <summary>
        /// 客户端支持工作区文件夹。
        /// </summary>
        /// <seealso>Spec 3.6.0</seealso>
        public bool workspaceFolders;

        /// <summary>
        /// 客户端支持 workspace/configuration 请求。
        /// </summary>
        /// <seealso>Spec 3.6.0</seealso>
        public bool configuration;
    }
}
