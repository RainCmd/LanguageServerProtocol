namespace LanguageServer.Parameters.General
{
    /// <summary>
    /// For <c>initialize</c>
    /// </summary>
    /// <seealso>Spec 3.10.0</seealso>
    public class ServerCapabilities
    {
        /// <summary>
        /// 服务器通过客户端功能' general.positionEncodings '从客户端提供的编码中选择位置编码。
        /// 
        /// 如果客户端没有提供任何位置编码，服务器可以返回的唯一有效值是'utf-16'。
        /// 
        /// 如果省略，则默认为'utf-16'。
        /// <see cref="PositionEncodingKind"/>
        /// </summary>
        public string? positionEncoding;
        /// <summary>
        /// 定义如何同步文本文档。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 是定义每个通知的详细结构，或者是向后兼容的TextDocumentSyncKind数字。
        /// </para>
        /// <para>
        /// If omitted it defaults to <c>TextDocumentSyncKind.None</c>.
        /// </para>
        /// </remarks>
        public TextDocumentSync? textDocumentSync;

        //todo notebookDocumentSync
        //NotebookDocumentSyncOptions NotebookDocumentSyncRegistrationOptions
        //public NotebookDocumentSyncOptions? notebookDocumentSync

        /// <summary>
        /// The server provides hover support.
        /// </summary>
        public bool? hoverProvider;

        /// <summary>
        /// The server provides completion support.
        /// </summary>
        public CompletionOptions? completionProvider;

        /// <summary>
        /// 服务器提供签名帮助支持。
        /// </summary>
        public SignatureHelpOptions? signatureHelpProvider;

        /// <summary>
        /// 服务器提供前往声明支持。
        /// </summary>
        public bool? declarationProvider;

        /// <summary>
        /// 服务器提供前往定义支持。
        /// </summary>
        public bool? definitionProvider;

        /// <summary>
        /// 服务器提供前往类型定义支持。
        /// </summary>
        /// <seealso>Spec 3.6.0</seealso>
        public ProviderOptionsOrBoolean? typeDefinitionProvider;

        /// <summary>
        /// 服务器提供前往实现支持。
        /// </summary>
        /// <seealso>Spec 3.6.0</seealso>
        public ProviderOptionsOrBoolean? implementationProvider;

        /// <summary>
        /// 服务器提供查找引用支持。
        /// </summary>
        public bool? referencesProvider;

        /// <summary>
        /// 服务器提供文档突出显示支持。
        /// </summary>
        public bool? documentHighlightProvider;

        /// <summary>
        /// 服务器提供文档符号支持。
        /// </summary>
        public bool? documentSymbolProvider;

        /// <summary>
        /// The server provides code actions.
        /// </summary>
        /// <remarks>
        /// The <c>CodeActionOptions</c> return type (since version 3.11.0) is only
        /// valid if the client signals code action literal support via the property
        /// <c>textDocument.codeAction.codeActionLiteralSupport</c>.
        /// 服务器提供代码操作。' CodeActionOptions '返回类型只有在客户端通过属性
        /// ' textDocument.codeAction.codeActionLiteralSupport '信号代码操作文字支持时才有效。
        /// </remarks>
        public bool? codeActionProvider;

        /// <summary>
        /// 服务器提供代码透镜。
        /// </summary>
        public CodeLensOptions? codeLensProvider;

        /// <summary>
        /// 服务器提供文档链接支持。
        /// </summary>
        public DocumentLinkOptions? documentLinkProvider;

        /// <summary>
        /// 服务器提供颜色提供程序支持。
        /// </summary>
        /// <remarks>
        /// 在代码中插入带颜色的小方块
        /// </remarks>
        /// <seealso>Spec 3.8.0</seealso>
        public ColorProviderOptionsOrBoolean? colorProvider;

        /// <summary>
        /// 服务器提供文档格式化。
        /// </summary>
        public bool? documentFormattingProvider;

        /// <summary>
        /// 服务器提供文档范围格式化。
        /// </summary>
        public bool? documentRangeFormattingProvider;

        /// <summary>
        /// 服务器在输入时提供文档格式。
        /// </summary>
        public DocumentOnTypeFormattingOptions? documentOnTypeFormattingProvider;

        /// <summary>
        /// 服务器提供重命名支持。
        /// </summary>
        /// <remarks>
        /// RenameOptions may only be specified if the client states that it supports
        /// <c>prepareSupport</c> in its initial <c>initialize</c> request.
        /// 服务器提供重命名支持。只有当客户端在初始的“initialize”请求中声明它支持“prepareSupport”时，才可以指定RenameOptions。
        /// </remarks>
        public RenameOptionsOrBoolean? renameProvider;

        /// <summary>
        /// 服务器提供折叠提供程序支持。
        /// </summary>
        /// <seealso>Spec 3.10.0</seealso>
        public FoldingRangeProviderOptionsOrBoolean? foldingRangeProvider;

        /// <summary>
        /// 服务器提供执行命令支持。
        /// </summary>
        public ExecuteCommandOptions? executeCommandProvider;

        /// <summary>
        /// 服务器提供选择范围支持。
        /// </summary>
        public ProviderOptionsOrBoolean? selectionRangeProvider;

        /// <summary>
        /// 服务器提供链接编辑范围支持。
        /// </summary>
        public ProviderOptionsOrBoolean? linkedEditingRangeProvider;

        /// <summary>
        /// 服务器提供调用层次结构支持。
        /// </summary>
        public ProviderOptionsOrBoolean? callHierarchyProvider;

        /// <summary>
        /// 服务器提供语义令牌支持。
        /// </summary>
        public ProviderOptionsOrBoolean? semanticTokensProvider;

        /// <summary>
        /// 服务器是否提供别名支持。
        /// </summary>
        public bool? monikerProvider;

        /// <summary>
        /// 服务器提供类型层次结构支持。
        /// </summary>
        public ProviderOptionsOrBoolean? typeHierarchyProvider;

        /// <summary>
        /// 服务器提供内联值。
        /// </summary>
        public ProviderOptionsOrBoolean? inlineValueProvider;

        /// <summary>
        /// 服务器提供嵌入提示。
        /// </summary>
        public ProviderOptionsOrBoolean? inlayHintProvider;

        /// <summary>
        /// 服务器支持拉模型诊断。
        /// </summary>
        public DiagnosticOptionsOrProviderOptions? diagnosticProvider;

        /// <summary>
        /// 服务器提供工作区符号支持。
        /// </summary>
        public bool? workspaceSymbolProvider;

        /// <summary>
        /// Workspace specific server capabilities
        /// </summary>
        /// <seealso>Spec 3.6.0</seealso>
        public WorkspaceOptions? workspace;

        /// <summary>
        /// 实验性服务器功能。
        /// </summary>
        public dynamic? experimental;
    }
}
