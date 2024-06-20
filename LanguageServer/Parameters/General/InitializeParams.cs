using LanguageServer.Parameters.Workspace;

namespace LanguageServer.Parameters.General
{
    /// <summary>
    /// For <c>initialize</c>
    /// </summary>
    public class InitializeParams(int processId, DocumentUri rootUri, ClientCapabilities capabilities)
    {
        /// <summary>
        /// 启动服务器的父进程的进程Id。
        /// </summary>
        public int processId = processId;

        /// <summary>
        /// 工作区的rootPath。如果没有打开文件夹，则为空。
        /// </summary>
        public string? rootPath;

        /// <summary>
        /// 工作区的rootUri。如果没有打开文件夹，则为空。
        /// 如果同时有<see cref="rootPath"/>和<see cref="rootUri"/>，则以后者为准
        /// </summary>
        public DocumentUri rootUri = rootUri;

        /// <summary>
        /// 客户端当前显示用户界面的语言环境。这不一定是操作系统的区域设置。
        /// </summary>
        public string? locale;

        /// <summary>
        /// 用户提供的初始化选项。
        /// </summary>
        public dynamic? initializationOptions;

        /// <summary>
        /// 客户端(编辑器或工具)提供的功能
        /// </summary>
        public ClientCapabilities capabilities = capabilities;

        /// <summary>
        /// 初始跟踪设置。
        /// </summary>
        /// <remarks>
        /// 如果省略，则禁用跟踪('off')。
        /// </remarks>
        /// <value>
        /// See <see cref="LanguageServer.Parameters.TraceKind"/> for an enumeration of standardized kinds.
        /// </value>
        /// <seealso cref="LanguageServer.Parameters.TraceKind"/>
        public string? trace;

        /// <summary>
        /// 服务器启动时在客户端中配置的工作区文件夹。
        /// </summary>
        /// <remarks>
        /// 此属性仅在客户端支持工作区文件夹时可用。
        /// 如果客户端支持工作空间文件夹但未配置，则可以为null。
        /// </remarks>
        /// <seealso>Spec 3.6.0</seealso>
        public WorkspaceFolder[]? workspaceFolders;
    }
}
