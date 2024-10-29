using LanguageServer.Parameters;
using LanguageServer.Parameters.General;
using LanguageServer.Parameters.TextDocument;
using LanguageServer.Parameters.Workspace;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace LanguageServer
{
    /// <summary>
    /// 语言服务连接
    /// 定义了基本的lsp交互接口并且对已实现接口提供自动初始化配置对象。
    /// </summary>
    /// <param name="input">输入流</param>
    /// <param name="output">输出流</param>
    /// <param name="timeout">请求处理的超时时间，单位毫秒</param>
    [RequiresDynamicCode("Calls LanguageServer.Reflector.GetRequestType(MethodInfo)")]
    public abstract class ServiceConnection(Stream input, Stream output, int timeout) : Connection(input, output, timeout)
    {
        /// <summary>
        /// 根据已实现的功能接口自动初始化一部分参数
        /// </summary>
        /// <returns></returns>
        protected ServerCapabilities GetServerCapabilities()
        {
            var capabilities = new HashSet<string>();
            foreach (var method in GetType().GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly))
            {
                var rpcMethod = method.GetCustomAttribute<JsonRpcMethodAttribute>()?.Method;
                if (rpcMethod != null) capabilities.Add(rpcMethod);
            }
            var result = new ServerCapabilities();
            if (capabilities.Contains("workspace/didChangeWorkspaceFolders") || capabilities.Contains("workspace/didChangeConfiguration") || capabilities.Contains("workspace/didChangeWatchedFiles"))
            {
                result.workspace ??= new WorkspaceOptions();
                result.workspace.workspaceFolders ??= new WorkspaceFoldersOptions();
                result.workspace.workspaceFolders.supported = true;
                result.workspace.workspaceFolders.changeNotifications = true;
            }
            if (capabilities.Contains("workspace/symbol")) result.workspaceSymbolProvider = true;
            if (capabilities.Contains("workspace/executeCommand"))
            {
                //result.executeCommandProvider
            }
            if (capabilities.Contains("textDocument/didOpen") || capabilities.Contains("textDocument/didClose"))
            {
                result.textDocumentSync ??= new TextDocumentSyncOptions();
                if (result.textDocumentSync.IsSecond)
                {
                    result.textDocumentSync.Second.openClose = true;
                    result.textDocumentSync.Second.change = TextDocumentSyncKind.Incremental;
                }
            }
            if (capabilities.Contains("textDocument/willSave"))
            {
                result.textDocumentSync ??= new TextDocumentSyncOptions();
                if (result.textDocumentSync.IsSecond)
                    result.textDocumentSync.Second.willSave = true;
            }
            if (capabilities.Contains("textDocument/completion") || capabilities.Contains("completionItem/resolve"))
            {
                result.completionProvider ??= new CompletionOptions();
                result.completionProvider.resolveProvider = true;
                result.completionProvider.triggerCharacters = ["."];
            }
            if (capabilities.Contains("textDocument/hover")) result.hoverProvider = true;
            if (capabilities.Contains("textDocument/signatureHelp")) result.signatureHelpProvider = new SignatureHelpOptions() { triggerCharacters = ["(", ","] };
            if (capabilities.Contains("textDocument/references")) result.referencesProvider = true;
            if (capabilities.Contains("textDocument/documentHighlight")) result.documentHighlightProvider = true;
            if (capabilities.Contains("textDocument/documentSymbol")) result.documentSymbolProvider = true;
            if (capabilities.Contains("textDocument/documentColor") || capabilities.Contains("textDocument/colorPresentation")) result.colorProvider = true;
            if (capabilities.Contains("textDocument/formatting")) result.documentFormattingProvider = true;
            if (capabilities.Contains("textDocument/rangeFormatting")) result.documentRangeFormattingProvider = true;
            if (capabilities.Contains("textDocument/onTypeFormatting")) result.documentOnTypeFormattingProvider = new DocumentOnTypeFormattingOptions();
            if (capabilities.Contains("textDocument/definition")) result.definitionProvider = true;
            if (capabilities.Contains("textDocument/typeDefinition")) result.typeDefinitionProvider = true;
            if (capabilities.Contains("textDocument/implementation")) result.implementationProvider = true;
            if (capabilities.Contains("textDocument/codeAction")) result.codeActionProvider = true;
            if (capabilities.Contains("textDocument/codeLens") || capabilities.Contains("codeLens/resolve"))
            {
                result.codeLensProvider ??= new CodeLensOptions();
                result.codeLensProvider.resolveProvider = true;
            }
            if (capabilities.Contains("textDocument/documentLink") || capabilities.Contains("documentLink/resolve"))
            {
                result.documentLinkProvider ??= new DocumentLinkOptions();
                result.documentLinkProvider.resolveProvider = true;
            }
            if (capabilities.Contains("textDocument/rename"))
            {
                if (capabilities.Contains("textDocument/prepareRename")) result.renameProvider = new RenameOptions() { prepareProvider = true };
                else result.renameProvider = true;
            }
            if (capabilities.Contains("textDocument/foldingRange")) result.foldingRangeProvider = true;
            if (capabilities.Contains("textDocument/diagnostic")) result.diagnosticProvider = new DiagnosticOptionsOrProviderOptions(new DiagnosticOptions(true, true));
            if (capabilities.Contains("textDocument/inlineValue")) result.inlineValueProvider = true;
            if (capabilities.Contains("textDocument/inlayHint")) result.inlayHintProvider = true;
            if (capabilities.Contains("textDocument/prepareCallHierarchy")) result.callHierarchyProvider = true;
            if (capabilities.Contains("textDocument/prepareTypeHierarchy")) result.typeHierarchyProvider = true;

            return result;
        }
        #region General

        [JsonRpcMethod("initialize")]
        protected virtual Result<InitializeResult, ResponseError<InitializeErrorData>> Initialize(InitializeParams param, CancellationToken token) => throw new NotImplementedException();

        [JsonRpcMethod("initialized")]
        protected virtual void Initialized() => throw new NotImplementedException();

        [JsonRpcMethod("shutdown")]
        protected virtual VoidResult<ResponseError> Shutdown(CancellationToken token) => throw new NotImplementedException();

        [JsonRpcMethod("exit")]
        protected virtual void Exit() => throw new NotImplementedException();

        #endregion

        #region Workspace

        /// <summary>
        /// workspace/didChangeWorkspaceFolders 通知从客户机发送到服务器，通知服务器有关工作区文件夹配置更改的信息。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 如果ServerCapabilities/workspace/workspaceFolders 和 ClientCapabilities/workspace/workspaceFolders 为 true 则默认发送通知
        /// 或者，如果服务器已注册接收此通知，则首先接收此通知。
        /// </para>
        /// <para>
        /// To register for the <c>workspace/didChangeWorkspaceFolders</c>
        /// send a <c>client/registerCapability</c> request from the client to the server.
        /// 注册参数必须具有以下形式的注册项:
        /// id 是用于取消注册功能的唯一id(本例使用UUID):
        /// </para>
        /// <code><![CDATA[{
        ///     id: "28c6150c-bd7b-11e7-abc4-cec278b6b50a",
        ///     method: "workspace/didChangeWorkspaceFolders"
        /// }]]></code>
        /// </remarks>
        /// <seealso>Spec 3.6.0</seealso>
        [JsonRpcMethod("workspace/didChangeWorkspaceFolders")]
        protected virtual void DidChangeWorkspaceFolders(DidChangeWorkspaceFoldersParams param) => throw new NotImplementedException();

        // dynamicRegistration?: boolean;
        /// <summary>
        /// 从客户机发送到服务器的通知，以表示配置设置的更改。
        /// </summary>
        [JsonRpcMethod("workspace/didChangeConfiguration")]
        protected virtual void DidChangeConfiguration(DidChangeConfigurationParams param) => throw new NotImplementedException();

        // dynamicRegistration?: boolean;
        /// <summary>
        /// 当客户端检测到语言客户端监视的文件和文件夹发生变化时，监视文件通知从客户端发送到服务器
        /// (注意，虽然名称表明只发送文件事件，但它是关于文件系统事件的，其中也包括文件夹)。
        /// 建议服务器使用注册机制注册这些文件系统事件。在以前的实现中，客户端推送文件事件而不需要服务器主动请求。
        /// </summary>
        /// <remarks>
        /// 允许服务器运行自己的文件系统监视机制，而不依赖于客户端提供文件系统事件。但是，由于以下原因，不建议这样做:
        /// <list type="bullet">
        /// <item>
        /// 根据我们的经验，在磁盘上正确地监视文件系统是具有挑战性的，特别是在需要跨多个操作系统支持的情况下。
        /// </item>
        /// <item>
        /// 文件系统监视不是免费的，特别是如果实现使用某种轮询并在内存中保存文件系统树来比较时间戳(例如一些节点模块所做的)。
        /// </item>
        /// <item>
        /// 一个客户端通常启动多个服务器。如果每个服务器都运行自己的文件系统监视，这可能会成为CPU或内存问题。
        /// </item>
        /// <item>
        /// 一般来说，服务器实现比客户端实现要多。所以这个问题最好在客户端解决。
        /// </item>
        /// </list>
        /// </remarks>
        [JsonRpcMethod("workspace/didChangeWatchedFiles")]
        protected virtual void DidChangeWatchedFiles(DidChangeWatchedFilesParams param) => throw new NotImplementedException();

        // dynamicRegistration?: boolean;
        // Registration Options: void
        /// <summary>
        /// 工作空间符号请求从客户端发送到服务器，以列出与查询字符串匹配的项目范围的符号。
        /// 自3.17.0以来，服务器还可以为workspacessymbol /resolve请求提供处理程序。
        /// 这允许服务器返回没有工作空间/符号请求范围的工作空间符号。
        /// 然后，客户端需要在必要时使用workspacessymbol /resolve请求解析该范围。
        /// 只有当客户端通过workspace.symbol. resolvessupport功能宣布支持该模型时，服务器才能使用该新模型。
        /// </summary>
        [JsonRpcMethod("workspace/symbol")]
        protected virtual Result<SymbolInformation[], ResponseError> Symbol(WorkspaceSymbolParams param, CancellationToken token) => throw new NotImplementedException();

        // dynamicRegistration?: boolean;
        // Registration Options: ExecuteCommandRegistrationOptions
        /// <summary>
        /// workspace/executeCommand请求从客户机发送到服务器，以触发服务器上的命令执行。
        /// 在大多数情况下，服务器创建一个WorkspaceEdit结构，并使用从服务器发送到客户端的请求workspace/applyEdit将更改应用到工作空间。
        /// </summary>
        [JsonRpcMethod("workspace/executeCommand")]
        protected virtual Result<dynamic, ResponseError> ExecuteCommand(ExecuteCommandParams param, CancellationToken token) => throw new NotImplementedException();

        #endregion

        #region TextDocument

        // Registration Options: TextDocumentRegistrationOptions
        /// <summary>
        /// 文档打开通知从客户机发送到服务器，以表示新打开的文本文档。
        /// 文档的内容现在由客户端管理，服务器不能尝试使用文档的Uri读取文档的内容。
        /// 在这个意义上，开放意味着它是由客户端管理的。这并不一定意味着它的内容在编辑器中显示。
        /// 在未发送相应的关闭通知之前，不得发送多次打开通知。这
        /// 意味着打开和关闭通知必须平衡，并且特定textDocument的最大打开计数为1。
        /// 请注意，服务器完成请求的能力与文本文档是打开还是关闭无关。
        /// </summary>
        /// <remarks>
        /// DidOpenTextDocumentParams包含与文档相关联的语言id。如果文档的语言id改变了，
        /// 客户端需要发送一个textDocument/didClose给服务器，如果服务器也处理新的语言id，
        /// 那么接着发送一个带有新语言id的textDocument/didOpen给服务器。
        /// </remarks>
        [JsonRpcMethod("textDocument/didOpen")]
        protected virtual void DidOpenTextDocument(DidOpenTextDocumentParams param) => throw new NotImplementedException();

        // Registration Options: TextDocumentChangeRegistrationOptions
        /// <summary>
        /// 文档更改通知从客户机发送到服务器，以表示对文本文档的更改。
        /// 在客户端可以更改文本文档之前，它必须使用textDocument/didOpen通知声明其内容的所有权。
        /// 在2.0中，参数的形状已经改变，以包含适当的版本号。
        /// </summary>
        [JsonRpcMethod("textDocument/didChange")]
        protected virtual void DidChangeTextDocument(DidChangeTextDocumentParams param) => throw new NotImplementedException();

        // Registration Options: TextDocumentRegistrationOptions
        /// <summary>
        /// 文档将保存通知在文档实际保存之前从客户机发送到服务器。
        /// 如果服务器已经注册了打开/关闭事件，客户端应该确保文档在发送willSave通知之前是打开的，
        /// 因为客户端不能在没有所有权转移的情况下更改文件的内容。
        /// </summary>
        [JsonRpcMethod("textDocument/willSave")]
        protected virtual void WillSaveTextDocument(WillSaveTextDocumentParams param) => throw new NotImplementedException();

        // Registration Options: TextDocumentRegistrationOptions
        /// <summary>
        /// 文档将保存请求在文档实际保存之前从客户机发送到服务器。请求可以返回一个TextEdits数组，
        /// 它将在保存文本文档之前应用于文本文档。请注意，如果计算文本编辑花费的时间太长，
        /// 或者服务器在此请求上不断失败，则客户端可能会丢失结果。这样做是为了保持保存的快速和可靠。
        /// 如果服务器已经注册了打开/关闭事件，客户端应该确保文档在发送willSaveWaitUntil通知之前是打开的，
        /// 因为客户端不能在没有所有权转移的情况下更改文件的内容。
        /// </summary>
        [JsonRpcMethod("textDocument/willSaveWaitUntil")]
        protected virtual Result<TextEdit[], ResponseError> WillSaveWaitUntilTextDocument(WillSaveTextDocumentParams param) => throw new NotImplementedException();

        // Registration Options: TextDocumentSaveRegistrationOptions
        /// <summary>
        /// 文档保存通知在文档保存到客户端时从客户端发送到服务器。
        /// </summary>
        [JsonRpcMethod("textDocument/didSave")]
        protected virtual void DidSaveTextDocument(DidSaveTextDocumentParams param) => throw new NotImplementedException();

        // Registration Options: TextDocumentRegistrationOptions
        /// <summary>
        /// 当文档在客户机中关闭时，文档关闭通知从客户机发送到服务器。
        /// 文档的master现在存在于文档的Uri指向的地方(例如，如果文档的Uri是一个文件Uri，
        /// 那么master现在存在于磁盘上)。与打开通知一样，关闭通知是关于管理文档内容的。
        /// 收到关闭通知并不意味着文档以前在编辑器中打开过。关闭通知需要发送先前打开的通知。
        /// 请注意，服务器完成请求的能力与文本文档是打开还是关闭无关。
        /// </summary>
        [JsonRpcMethod("textDocument/didClose")]
        protected virtual void DidCloseTextDocument(DidCloseTextDocumentParams param) => throw new NotImplementedException();

        /// <summary>
        /// 完成请求从客户机发送到服务器，以在给定的光标位置计算完成项。
        /// </summary>
        /// <remarks>
        /// <para>
        /// Completion items are presented in the <a href="https://code.visualstudio.com/docs/editor/editingevolved#_intellisense">IntelliSense</a> user interface.
        /// If computing full completion items is expensive, servers can additionally provide a handler for the completion item resolve request (<c>completionItem/resolve</c>).
        /// </para>
        /// <para>
        /// 当在用户界面中选择完成项时发送此请求。
        /// </para>
        /// <para>
        /// 一个典型的用例是:textDocument/completion 请求没有填充
        /// 返回的补全项的文档属性中，因为计算成本很高。
        /// 当项目在用户界面中被选中时，就会出现一个 completionItem/resolve 请求
        /// 与选定的完成项一起作为参数发送。
        /// </para>
        /// <para>
        /// Registration Options: <c>CompletionRegistrationOptions</c>
        /// </para>
        /// </remarks>
        /// <seealso cref="TextDocumentClientCapabilities"/>
        /// <seealso>Spec 3.3.0</seealso>
        [JsonRpcMethod("textDocument/completion")]
        protected virtual Result<CompletionResult, ResponseError> Completion(CompletionParams param, CancellationToken token) => throw new NotImplementedException();

        /// <summary>
        /// 请求从客户机发送到服务器，以解析给定完成项的附加信息。
        /// </summary>
        [JsonRpcMethod("completionItem/resolve")]
        protected virtual Result<CompletionItem, ResponseError> ResolveCompletionItem(CompletionItem param, CancellationToken token) => throw new NotImplementedException();

        // dynamicRegistration?: boolean;
        // Registration Options: TextDocumentRegistrationOptions
        /// <summary>
        /// 悬停请求从客户端发送到服务器，以请求在给定文本文档位置的悬停信息。
        /// </summary>
        [JsonRpcMethod("textDocument/hover")]
        protected virtual Result<Hover, ResponseError> Hover(TextDocumentPositionParams param, CancellationToken token) => throw new NotImplementedException();

        // dynamicRegistration?: boolean;
        // Registration Options: SignatureHelpRegistrationOptions
        /// <summary>
        /// 签名帮助请求从客户机发送到服务器，以请求给定光标位置的签名信息。
        /// </summary>
        [JsonRpcMethod("textDocument/signatureHelp")]
        protected virtual Result<SignatureHelp, ResponseError> SignatureHelp(TextDocumentPositionParams param, CancellationToken token) => throw new NotImplementedException();

        // dynamicRegistration?: boolean;
        // Registration Options: TextDocumentRegistrationOptions
        /// <summary>
        /// 引用请求从客户端发送到服务器，以解析由给定文本文档位置表示的符号的项目范围引用。
        /// </summary>
        [JsonRpcMethod("textDocument/references")]
        protected virtual Result<Location[], ResponseError> FindReferences(ReferenceParams param, CancellationToken token) => throw new NotImplementedException();

        // dynamicRegistration?: boolean;
        // Registration Options: TextDocumentRegistrationOptions
        /// <summary>
        /// 文档突出显示请求从客户机发送到服务器，以解析给定文本文档位置的文档突出显示。
        /// 对于编程语言，这通常突出显示对该文件范围内的符号的所有引用。
        /// 但是，我们保留了“textDocument/documentHighlight”和“textDocument/references”单独的请求，
        /// 因为第一个被允许更加模糊。符号匹配通常有一个“读”或“写”的DocumentHighlightKind，而模糊或文本匹配使用“文本”作为类型。
        /// </summary>
        [JsonRpcMethod("textDocument/documentHighlight")]
        protected virtual Result<DocumentHighlight[], ResponseError> DocumentHighlight(TextDocumentPositionParams param, CancellationToken token) => throw new NotImplementedException();

        /// <summary>
        /// 文档符号请求从客户机发送到服务器
        /// 返回给定文本文档中找到的所有符号的平面列表。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 符号的位置范围和符号的容器名都不能用来推断层次结构。
        /// </para>
        /// <para>
        /// Registration Options: <c>TextDocumentRegistrationOptions</c>
        /// </para>
        /// </remarks>
        /// <seealso cref="TextDocumentClientCapabilities"/>
        /// <seealso>Spec 3.10.0</seealso>
        [JsonRpcMethod("textDocument/documentSymbol")]
        protected virtual Result<DocumentSymbolResult, ResponseError> DocumentSymbols(DocumentSymbolParams param, CancellationToken token) => throw new NotImplementedException();

        /// <summary>
        /// 文档颜色请求从客户机发送到服务器
        /// 列出在给定文本文档中找到的所有颜色参考。
        /// 除了这个范围，还返回一个RGB的颜色值。
        /// </summary>
        /// <remarks>
        /// 客户端可以使用结果来装饰编辑器中的颜色引用。例如:
        /// <list type="bullet">
        /// <item><description>颜色框显示参考旁边的实际颜色</description></item>
        /// <item><description>在编辑颜色参考时显示颜色选择器</description></item>
        /// </list>
        /// </remarks>
        /// <seealso>Spec 3.6.0</seealso>
        [JsonRpcMethod("textDocument/documentColor")]
        protected virtual Result<ColorInformation[], ResponseError> DocumentColor(DocumentColorParams param, CancellationToken token) => throw new NotImplementedException();

        /// <summary>
        /// 颜色表示请求从客户机发送到服务器
        /// 获取给定位置上颜色值的表示列表。
        /// </summary>
        /// <remarks>
        /// 客户端可以使用结果来
        /// <list type="bullet">
        /// <item><description>修改颜色参考。</description></item>
        /// <item><description>在颜色选择器中显示，并让用户选择其中一个演示文稿</description></item>
        /// </list>
        /// </remarks>
        /// <seealso>Spec 3.6.0</seealso>
        [JsonRpcMethod("textDocument/colorPresentation")]
        protected virtual Result<ColorPresentation[], ResponseError> ColorPresentation(ColorPresentationParams param, CancellationToken token) => throw new NotImplementedException();

        // dynamicRegistration?: boolean;
        // Registration Options: TextDocumentRegistrationOptions
        /// <summary>
        /// 文档格式化请求从客户机发送到服务器以格式化整个文档。
        /// </summary>
        [JsonRpcMethod("textDocument/formatting")]
        protected virtual Result<TextEdit[], ResponseError> DocumentFormatting(DocumentFormattingParams param, CancellationToken token) => throw new NotImplementedException();

        // dynamicRegistration?: boolean;
        // Registration Options: TextDocumentRegistrationOptions
        /// <summary>
        /// 文档范围格式化请求从客户机发送到服务器，以格式化文档中的给定范围。
        /// </summary>
        [JsonRpcMethod("textDocument/rangeFormatting")]
        protected virtual Result<TextEdit[], ResponseError> DocumentRangeFormatting(DocumentRangeFormattingParams param, CancellationToken token) => throw new NotImplementedException();

        // dynamicRegistration?: boolean;
        // Registration Options: DocumentOnTypeFormattingRegistrationOptions
        /// <summary>
        /// 文档的类型格式化请求从客户端发送到服务器，以便在键入过程中格式化文档的部分内容。
        /// </summary>
        [JsonRpcMethod("textDocument/onTypeFormatting")]
        protected virtual Result<TextEdit[], ResponseError> DocumentOnTypeFormatting(DocumentOnTypeFormattingParams param, CancellationToken token) => throw new NotImplementedException();

        /// <summary>
        /// goto定义请求从客户机发送到服务器
        /// 以解析给定文本文档位置上符号的定义位置。
        /// </summary>
        /// <remarks>
        /// Registration Options: <c>TextDocumentRegistrationOptions</c>
        /// </remarks>
        /// <seealso cref="TextDocumentClientCapabilities"/>
        [JsonRpcMethod("textDocument/definition")]
        protected virtual Result<LocationSingleOrArray, ResponseError> GotoDefinition(TextDocumentPositionParams param, CancellationToken token) => throw new NotImplementedException();

        /// <summary>
        /// goto类型定义请求从客户机发送到服务器
        /// 解析符号在给定文本文档位置上的类型定义位置。
        /// </summary>
        /// <remarks>
        /// Registration Options: <c>TextDocumentRegistrationOptions</c>
        /// </remarks>
        /// <seealso cref="TextDocumentClientCapabilities"/>
        /// <seealso>Spec 3.6.0</seealso>
        [JsonRpcMethod("textDocument/typeDefinition")]
        protected virtual Result<LocationSingleOrArray, ResponseError> GotoTypeDefinition(TextDocumentPositionParams param, CancellationToken token) => throw new NotImplementedException();

        /// <summary>
        /// goto实现请求从客户机发送到服务器
        /// 解析符号在给定文本文档位置上的实现位置。
        /// </summary>
        /// <remarks>
        /// Registration Options: <c>TextDocumentRegistrationOptions</c>
        /// </remarks>
        /// <seealso cref="TextDocumentClientCapabilities"/>
        /// <seealso>Spec 3.6.0</seealso>
        [JsonRpcMethod("textDocument/implementation")]
        protected virtual Result<LocationSingleOrArray, ResponseError> GotoImplementation(TextDocumentPositionParams param, CancellationToken token) => throw new NotImplementedException();

        /// <summary>
        /// 代码操作请求从客户机发送到服务器
        /// 为给定的文本文档和范围计算命令。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 这些命令通常是代码修复，用于修复问题或美化/重构代码。
        /// textDocument/codeAction 请求的结果时一个 Command 数组，它们通常呈现在用户界面中。
        /// 选中该命令后，需要再次与服务器联系(通过 workspace/executeCommand 请求) 来执行命令
        /// </para>
        /// <para>
        /// <i>Since version 3.8.0:</i> 支持CodeAction字面值以启用以下场景:
        /// <list type="bullet">
        /// <item><description>
        /// 从代码操作请求直接返回工作区编辑的能力。
        /// 这避免了另一个服务器往返来执行实际的代码操作。
        /// 但是，服务器提供者应该意识到，如果代码操作的计算成本很高，或者编辑量很大，
        /// 那么如果结果只是一个命令，并且只在需要时才计算实际的编辑，那么这可能仍然是有益的。
        /// </description></item>
        /// <item><description>
        /// 使用类对代码操作进行分组的能力。客户端可以忽略这些信息。
        /// 然而，它允许他们更好地将代码操作分组到相应的菜单中
        /// (例如，将所有重构代码操作分组到一个重构菜单中)。
        /// </description></item>
        /// </list>
        /// </para>
        /// <para>
        /// 客户端需要通过相应的客户端功能宣布它们对代码操作文字和代码操作类型的支持
        /// <c>textDocument.codeAction.codeActionLiteralSupport</c>.
        /// </para>
        /// <para>
        /// Registration Options: <c>TextDocumentRegistrationOptions</c>
        /// </para>
        /// </remarks>
        /// <seealso cref="TextDocumentClientCapabilities"/>
        /// <seealso>Spec 3.8.0</seealso>
        [JsonRpcMethod("textDocument/codeAction")]
        protected virtual Result<CodeActionResult, ResponseError> CodeAction(CodeActionParams param, CancellationToken token) => throw new NotImplementedException();

        // dynamicRegistration?: boolean;
        // Registration Options: CodeLensRegistrationOptions
        /// <summary>
        /// 代码透镜请求从客户机发送到服务器，以计算给定文本文档的代码透镜。
        /// </summary>
        [JsonRpcMethod("textDocument/codeLens")]
        protected virtual Result<CodeLens[], ResponseError> CodeLens(CodeLensParams param, CancellationToken token) => throw new NotImplementedException();

        /// <summary>
        /// 代码透镜解析请求从客户机发送到服务器，以解析给定代码透镜项的命令。
        /// </summary>
        [JsonRpcMethod("codeLens/resolve")]
        protected virtual Result<CodeLens, ResponseError> ResolveCodeLens(CodeLens param, CancellationToken token) => throw new NotImplementedException();

        // dynam0icRegistration?: boolean;
        // Registration Options: DocumentLinkRegistrationOptions
        /// <summary>
        /// 文档链接请求从客户机发送到服务器，以请求文档中链接的位置。
        /// </summary>
        [JsonRpcMethod("textDocument/documentLink")]
        protected virtual Result<DocumentLink[], ResponseError> DocumentLink(DocumentLinkParams param, CancellationToken token) => throw new NotImplementedException();

        /// <summary>
        /// 文档链接解析请求从客户机发送到服务器，以解析给定文档链接的目标。
        /// </summary>
        [JsonRpcMethod("documentLink/resolve")]
        protected virtual Result<DocumentLink, ResponseError> ResolveDocumentLink(DocumentLink param, CancellationToken token) => throw new NotImplementedException();

        /// <summary>
        /// 准备重命名请求从客户端发送到服务器，用于在给定位置设置并测试重命名操作的有效性。
        /// </summary>
        /// <seealso>Since version 3.12.0</seealso>>
        /// <exception cref="NotImplementedException"></exception>
        [JsonRpcMethod("textDocument/prepareRename")]
        protected virtual Result<Parameters.Range, ResponseError> PrepareRename(TextDocumentPositionParams param, CancellationToken token) => throw new NotImplementedException();

        // dynamicRegistration?: boolean;
        // Registration Options: TextDocumentRegistrationOptions
        /// <summary>
        /// 符号的新名称。如果给定的名称无效，请求必须返回一个带有适当消息集的[ResponseError](#ResponseError)。
        /// </summary>
        [JsonRpcMethod("textDocument/rename")]
        protected virtual Result<WorkspaceEdit, ResponseError> Rename(RenameParams param, CancellationToken token) => throw new NotImplementedException();

        /// <summary>
        /// 折叠范围请求从客户机发送到服务器，
        /// 以返回给定文本文档中找到的所有折叠范围。
        /// </summary>
        /// <seealso>Spec 3.10.0</seealso>
        [JsonRpcMethod("textDocument/foldingRange")]
        protected virtual Result<FoldingRange[], ResponseError> FoldingRange(FoldingRangeRequestParam param, CancellationToken token) => throw new NotImplementedException();

        /// <summary>
        /// 文本文档诊断请求从客户机发送到服务器，请求服务器计算给定文档的诊断结果。
        /// 与其他拉取请求一样，服务器被要求计算当前同步版本文档的诊断信息。
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        [JsonRpcMethod("textDocument/diagnostic")]
        protected virtual Result<DocumentDiagnosticReport, ResponseError> DocumentDiagnostic(DocumentDiagnosticParams param, CancellationToken token) => throw new NotImplementedException();

        /// <summary>
        /// 内联值请求从客户机发送到服务器，以计算给定文本文档的内联值，这些文本文档可能会在编辑器的行尾呈现。
        /// </summary>
        /// <seealso>Spec 3.17.0</seealso>
        /// <exception cref="NotImplementedException"></exception>
        [JsonRpcMethod("textDocument/inlineValue")]
        protected virtual Result<InlineValueResult[], ResponseError> InlineValue(InlineValueParams param, CancellationToken token) => throw new NotImplementedException();

        /// <summary>
        /// 嵌入提示请求从客户机发送到服务器，以计算给定[text document, range]元组的嵌入提示，该元组可能在编辑器中与其他文本一起呈现。
        /// </summary>
        /// <seealso>Spec 3.17.0</seealso>
        /// <exception cref="NotImplementedException"></exception>
        [JsonRpcMethod("textDocument/inlayHint")]
        protected virtual Result<InlayHintResult[], ResponseError> InlayHint(InlayHintParams param, CancellationToken token) => throw new NotImplementedException();

        /// <summary>
        /// 请求从客户机发送到服务器，以解析给定嵌入提示的附加信息。这通常用于计算工具提示，
        /// 位置或嵌入提示的标签部分的命令属性，以避免在textDocument/inlayHint请求期间进行不必要的计算。
        /// </summary>
        /// <seealso>Spec 3.17.0</seealso>
        /// <exception cref="NotImplementedException"></exception>
        [JsonRpcMethod("inlayHint/resolve")]
        protected virtual Result<InlayHintResult, ResponseError> InlayHintResolve(InlayHintResult param, CancellationToken token) => throw new NotImplementedException();

        /// <summary>
        /// 调用层次结构请求从客户端发送到服务器，以返回给定文本文档位置的 language 元素的调用层次结构。调用层次结构请求分两步执行：
        /// 1.首先，为给定的文本文档位置解析 Call hierarchy 项
        /// 2.对于呼叫层次结构项目，将解析传入或传出呼叫层次结构项目。
        /// </summary>
        /// <seealso>Spec 3.16.0</seealso>
        /// <exception cref="NotImplementedException"></exception>
        [JsonRpcMethod("textDocument/prepareCallHierarchy")]
        protected virtual Result<CallHierarchyItem[], ResponseError> PrepareCallHierarchy(CallHierarchyPrepareParams param, CancellationToken token) => throw new NotImplementedException();

        /// <summary>
        /// 该请求从客户端发送到服务器，以解析给定调用层次结构项的传入呼叫。
        /// 该请求未定义自己的客户端和服务器功能。
        /// 仅当服务器注册 textDocument/prepareCallHierarchy 请求时，才会发出此请求。
        /// </summary>
        /// <seealso>Spec 3.16.0</seealso>
        /// <exception cref="NotImplementedException"></exception>
        [JsonRpcMethod("callHierarchy/incomingCalls")]
        protected virtual Result<CallHierarchyIncomingCall[], ResponseError> CallHierarchyIncomingCalls(CallHierarchyIncomingCallsParams param, CancellationToken token) => throw new NotImplementedException();

        /// <summary>
        /// 该请求从客户端发送到服务器，以解析给定调用层次结构项的传出呼叫。
        /// 该请求未定义自己的客户端和服务器功能。
        /// 仅当服务器注册 textDocument/prepareCallHierarchy 请求时，才会发出此请求。
        /// </summary>
        /// <seealso>Spec 3.16.0</seealso>
        /// <exception cref="NotImplementedException"></exception>
        [JsonRpcMethod("callHierarchy/outgoingCalls")]
        protected virtual Result<CallHierarchyOutgoingCall[], ResponseError> CallHierarchyOutgoingCalls(CallHierarchyOutgoingCallsParams param, CancellationToken token) => throw new NotImplementedException();

        /// <summary>
        /// 类型层次结构请求从客户端发送到服务器，以返回给定文本文档位置的 language 元素的类型层次结构。如果服务器无法从位置推断出有效类型，则返回。类型层次结构请求分两个步骤执行：
        /// 1.首先，为给定的文本文档位置准备一个类型层次结构项。
        /// 2.对于类型层次结构项，将解析 SuperType 或 Subtype Type 层次结构项。
        /// </summary>
        /// <seealso>Spec 3.17.0</seealso>
        /// <exception cref="NotImplementedException"></exception>
        [JsonRpcMethod("textDocument/prepareTypeHierarchy")]
        protected virtual Result<TypeHierarchyItem[], ResponseError> PrepareTypeHierarchy(TypeHierarchyPrepareParams param, CancellationToken token) => throw new NotImplementedException();

        /// <summary>
        /// 该请求从客户端发送到服务器，以解析给定类型层次结构项的超类型。
        /// 如果服务器无法从 params 中推断出有效类型，则返回。
        /// 该请求未定义自己的客户端和服务器功能。
        /// 仅当服务器注册 textDocument/prepareTypeHierarchy 请求时，才会发出此命令。
        /// </summary>
        /// <seealso>Spec 3.16.0</seealso>
        /// <exception cref="NotImplementedException"></exception>
        [JsonRpcMethod("typeHierarchy/supertypes")]
        protected virtual Result<TypeHierarchyItem[], ResponseError> TypeHierarchySupertypes(TypeHierarchySupertypesParams param, CancellationToken token) => throw new NotImplementedException();

        /// <summary>
        /// 该请求从客户端发送到服务器，以解析给定类型层次结构项目的子类型。
        /// 如果服务器无法从 params 中推断出有效类型，则返回。
        /// 该请求未定义自己的客户端和服务器功能。
        /// 仅当服务器注册 textDocument/prepareTypeHierarchy 请求时，才会发出此命令。
        /// </summary>
        /// <seealso>Spec 3.16.0</seealso>
        /// <exception cref="NotImplementedException"></exception>
        [JsonRpcMethod("typeHierarchy/subtypes")]
        protected virtual Result<TypeHierarchyItem[], ResponseError> TypeHierarchySubtypes(TypeHierarchySubtypesParams param, CancellationToken token) => throw new NotImplementedException();
        #endregion
    }
}
