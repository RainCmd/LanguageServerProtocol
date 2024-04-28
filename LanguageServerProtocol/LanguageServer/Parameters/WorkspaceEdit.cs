using LanguageServer.Parameters.Workspace;

namespace LanguageServer.Parameters
{

    /// <summary>
    /// For <c>textDocument/rename</c> and <c>workspace/applyEdit</c>
    /// </summary>
    /// <remarks>
    /// 工作区编辑表示对工作区中管理的许多资源的更改。编辑应该提供<c>changes</c>或<c>documentChanges</c>。
    /// 如果客户端可以处理版本化的文档编辑，并且存在<c>documentChanges</c>，则后者优于<c>changes</c>。
    /// </remarks>
    /// <seealso>Spec 3.1.0</seealso>
    public class WorkspaceEdit
    {
        /// <summary>
        /// 保存对现有资源的更改。
        /// </summary>
        public Dictionary<WorkspaceFolder, TextEdit[]>? changes;

        /// <summary>
        /// <c>TextDocumentEdit</c>s数组表示对n个不同文本文档的更改，其中每个文本文档编辑针对文本文档的特定版本。
        /// 客户端是否支持版本化的文档编辑通过<c>WorkspaceClientCapabilities.workspaceEdit.documentChanges</c>表示。
        /// </summary>
        public TextDocumentEdit[]? documentChanges;

        /// <summary>
        /// 更改注释的映射，可以在' AnnotatedTextEdit ' s或创建、重命名和删除文件/文件夹操作中引用。
        /// </summary>
        /// <remarks>
        /// 客户端是否支持此属性取决于客户端功能' workspace.changeAnnotationSupport '。
        /// </remarks>
        public Dictionary<string, ChangeAnnotation>? changeAnnotations;
    }
}
