using LanguageServer.Parameters;
using LanguageServer.Parameters.General;
using LanguageServer.Parameters.TextDocument;
using LanguageServer.Parameters.Workspace;
using System.Diagnostics.CodeAnalysis;

namespace LanguageServer
{
    [RequiresDynamicCode("Calls LanguageServer.Reflector.GetRequestType(MethodInfo)")]
    public abstract class ServiceConnection(Stream input, Stream output) : Connection(input, output)
    {
        #region General

        [JsonRpcMethod("initialize")]
        protected virtual Result<InitializeResult, ResponseError<InitializeErrorData>> Initialize(InitializeParams @params, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        [JsonRpcMethod("initialized")]
        protected virtual void Initialized()
        {
            throw new NotImplementedException();
        }

        [JsonRpcMethod("shutdown")]
        protected virtual VoidResult<ResponseError> Shutdown(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        [JsonRpcMethod("exit")]
        protected virtual void Exit()
        {
            throw new NotImplementedException();
        }

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
        /// <param name="params"></param>
        /// <seealso>Spec 3.6.0</seealso>
        [JsonRpcMethod("workspace/didChangeWorkspaceFolders")]
        protected virtual void DidChangeWorkspaceFolders(DidChangeWorkspaceFoldersParams @params)
        {
            throw new NotImplementedException();
        }

        // dynamicRegistration?: boolean;
        [JsonRpcMethod("workspace/didChangeConfiguration")]
        protected virtual void DidChangeConfiguration(DidChangeConfigurationParams @params)
        {
            throw new NotImplementedException();
        }

        // dynamicRegistration?: boolean;
        [JsonRpcMethod("workspace/didChangeWatchedFiles")]
        protected virtual void DidChangeWatchedFiles(DidChangeWatchedFilesParams @params)
        {
            throw new NotImplementedException();
        }

        // dynamicRegistration?: boolean;
        // Registration Options: void
        [JsonRpcMethod("workspace/symbol")]
        protected virtual Result<SymbolInformation[], ResponseError> Symbol(WorkspaceSymbolParams @params, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        // dynamicRegistration?: boolean;
        // Registration Options: ExecuteCommandRegistrationOptions
        [JsonRpcMethod("workspace/executeCommand")]
        protected virtual Result<dynamic, ResponseError> ExecuteCommand(ExecuteCommandParams @params, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region TextDocument

        // Registration Options: TextDocumentRegistrationOptions
        [JsonRpcMethod("textDocument/didOpen")]
        protected virtual void DidOpenTextDocument(DidOpenTextDocumentParams @params)
        {
            throw new NotImplementedException();
        }

        // Registration Options: TextDocumentChangeRegistrationOptions
        [JsonRpcMethod("textDocument/didChange")]
        protected virtual void DidChangeTextDocument(DidChangeTextDocumentParams @params)
        {
        }

        // Registration Options: TextDocumentRegistrationOptions
        [JsonRpcMethod("textDocument/willSave")]
        protected virtual void WillSaveTextDocument(WillSaveTextDocumentParams @params)
        {
            throw new NotImplementedException();
        }

        // Registration Options: TextDocumentRegistrationOptions
        [JsonRpcMethod("textDocument/willSaveWaitUntil")]
        protected virtual Result<TextEdit[], ResponseError> WillSaveWaitUntilTextDocument(WillSaveTextDocumentParams @params)
        {
            throw new NotImplementedException();
        }

        // Registration Options: TextDocumentSaveRegistrationOptions
        [JsonRpcMethod("textDocument/didSave")]
        protected virtual void DidSaveTextDocument(DidSaveTextDocumentParams @params)
        {
            throw new NotImplementedException();
        }

        // Registration Options: TextDocumentRegistrationOptions
        [JsonRpcMethod("textDocument/didClose")]
        protected virtual void DidCloseTextDocument(DidCloseTextDocumentParams @params)
        {
            throw new NotImplementedException();
        }

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
        /// <param name="params"></param>
        /// <returns></returns>
        /// <seealso cref="LanguageServer.Parameters.General.TextDocumentClientCapabilities"/>
        /// <seealso>Spec 3.3.0</seealso>
        [JsonRpcMethod("textDocument/completion")]
        protected virtual Result<CompletionResult, ResponseError> Completion(CompletionParams @params, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        [JsonRpcMethod("completionItem/resolve")]
        protected virtual Result<CompletionItem, ResponseError> ResolveCompletionItem(CompletionItem @params, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        // dynamicRegistration?: boolean;
        // Registration Options: TextDocumentRegistrationOptions
        [JsonRpcMethod("textDocument/hover")]
        protected virtual Result<Hover, ResponseError> Hover(TextDocumentPositionParams @params, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        // dynamicRegistration?: boolean;
        // Registration Options: SignatureHelpRegistrationOptions
        [JsonRpcMethod("textDocument/signatureHelp")]
        protected virtual Result<SignatureHelp, ResponseError> SignatureHelp(TextDocumentPositionParams @params, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        // dynamicRegistration?: boolean;
        // Registration Options: TextDocumentRegistrationOptions
        [JsonRpcMethod("textDocument/references")]
        protected virtual Result<Location[], ResponseError> FindReferences(ReferenceParams @params, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        // dynamicRegistration?: boolean;
        // Registration Options: TextDocumentRegistrationOptions
        [JsonRpcMethod("textDocument/documentHighlight")]
        protected virtual Result<DocumentHighlight[], ResponseError> DocumentHighlight(TextDocumentPositionParams @params, CancellationToken token)
        {
            throw new NotImplementedException();
        }

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
        /// <param name="params"></param>
        /// <returns></returns>
        /// <seealso cref="LanguageServer.Parameters.General.TextDocumentClientCapabilities"/>
        /// <seealso>Spec 3.10.0</seealso>
        [JsonRpcMethod("textDocument/documentSymbol")]
        protected virtual Result<DocumentSymbolResult, ResponseError> DocumentSymbols(DocumentSymbolParams @params, CancellationToken token)
        {
            throw new NotImplementedException();
        }

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
        /// <param name="params"></param>
        /// <returns></returns>
        /// <seealso>Spec 3.6.0</seealso>
        [JsonRpcMethod("textDocument/documentColor")]
        protected virtual Result<ColorInformation[], ResponseError> DocumentColor(DocumentColorParams @params, CancellationToken token)
        {
            throw new NotImplementedException();
        }

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
        /// <param name="params"></param>
        /// <returns></returns>
        /// <seealso>Spec 3.6.0</seealso>
        [JsonRpcMethod("textDocument/colorPresentation")]
        protected virtual Result<ColorPresentation[], ResponseError> ColorPresentation(ColorPresentationParams @params, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        // dynamicRegistration?: boolean;
        // Registration Options: TextDocumentRegistrationOptions
        [JsonRpcMethod("textDocument/formatting")]
        protected virtual Result<TextEdit[], ResponseError> DocumentFormatting(DocumentFormattingParams @params, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        // dynamicRegistration?: boolean;
        // Registration Options: TextDocumentRegistrationOptions
        [JsonRpcMethod("textDocument/rangeFormatting")]
        protected virtual Result<TextEdit[], ResponseError> DocumentRangeFormatting(DocumentRangeFormattingParams @params, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        // dynamicRegistration?: boolean;
        // Registration Options: DocumentOnTypeFormattingRegistrationOptions
        [JsonRpcMethod("textDocument/onTypeFormatting")]
        protected virtual Result<TextEdit[], ResponseError> DocumentOnTypeFormatting(DocumentOnTypeFormattingParams @params, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// goto定义请求从客户机发送到服务器
        /// 以解析给定文本文档位置上符号的定义位置。
        /// </summary>
        /// <remarks>
        /// Registration Options: <c>TextDocumentRegistrationOptions</c>
        /// </remarks>
        /// <param name="params"></param>
        /// <returns></returns>
        /// <seealso cref="LanguageServer.Parameters.General.TextDocumentClientCapabilities"/>
        [JsonRpcMethod("textDocument/definition")]
        protected virtual Result<LocationSingleOrArray, ResponseError> GotoDefinition(TextDocumentPositionParams @params, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// goto类型定义请求从客户机发送到服务器
        /// 解析符号在给定文本文档位置上的类型定义位置。
        /// </summary>
        /// <remarks>
        /// Registration Options: <c>TextDocumentRegistrationOptions</c>
        /// </remarks>
        /// <param name="params"></param>
        /// <returns></returns>
        /// <seealso cref="LanguageServer.Parameters.General.TextDocumentClientCapabilities"/>
        /// <seealso>Spec 3.6.0</seealso>
        [JsonRpcMethod("textDocument/typeDefinition")]
        protected virtual Result<LocationSingleOrArray, ResponseError> GotoTypeDefinition(TextDocumentPositionParams @params, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// goto实现请求从客户机发送到服务器
        /// 解析符号在给定文本文档位置上的实现位置。
        /// </summary>
        /// <remarks>
        /// Registration Options: <c>TextDocumentRegistrationOptions</c>
        /// </remarks>
        /// <param name="params"></param>
        /// <returns></returns>
        /// <seealso cref="LanguageServer.Parameters.General.TextDocumentClientCapabilities"/>
        /// <seealso>Spec 3.6.0</seealso>
        [JsonRpcMethod("textDocument/implementation")]
        protected virtual Result<LocationSingleOrArray, ResponseError> GotoImplementation(TextDocumentPositionParams @params, CancellationToken token)
        {
            throw new NotImplementedException();
        }

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
        /// <param name="params"></param>
        /// <returns></returns>
        /// <seealso cref="LanguageServer.Parameters.General.TextDocumentClientCapabilities"/>
        /// <seealso>Spec 3.8.0</seealso>
        [JsonRpcMethod("textDocument/codeAction")]
        protected virtual Result<CodeActionResult, ResponseError> CodeAction(CodeActionParams @params, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        // dynamicRegistration?: boolean;
        // Registration Options: CodeLensRegistrationOptions
        [JsonRpcMethod("textDocument/codeLens")]
        protected virtual Result<CodeLens[], ResponseError> CodeLens(CodeLensParams @params, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        [JsonRpcMethod("codeLens/resolve")]
        protected virtual Result<CodeLens, ResponseError> ResolveCodeLens(CodeLens @params, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        // dynam0icRegistration?: boolean;
        // Registration Options: DocumentLinkRegistrationOptions
        [JsonRpcMethod("textDocument/documentLink")]
        protected virtual Result<DocumentLink[], ResponseError> DocumentLink(DocumentLinkParams @params, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        [JsonRpcMethod("documentLink/resolve")]
        protected virtual Result<DocumentLink, ResponseError> ResolveDocumentLink(DocumentLink @params, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        // dynamicRegistration?: boolean;
        // Registration Options: TextDocumentRegistrationOptions
        [JsonRpcMethod("textDocument/rename")]
        protected virtual Result<WorkspaceEdit, ResponseError> Rename(RenameParams @params, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 折叠范围请求从客户机发送到服务器，
        /// 以返回给定文本文档中找到的所有折叠范围。
        /// </summary>
        /// <param name="params"></param>
        /// <returns></returns>
        /// <seealso>Spec 3.10.0</seealso>
        [JsonRpcMethod("textDocument/foldingRange")]
        protected virtual Result<FoldingRange[], ResponseError> FoldingRange(FoldingRangeRequestParam @params, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
