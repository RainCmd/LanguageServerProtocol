namespace LanguageServer.Parameters.TextDocument
{
    /// <summary>
    /// For <c>textDocument/codeAction</c>
    /// </summary>
    /// <remarks>
    /// <para>
    /// 代码操作表示可以在代码中执行的更改，例如修复问题或重构代码。
    /// </para>
    /// <para>
    /// A CodeAction must set either <c>edit</c> and/or a <c>command</c>.
    /// If both are supplied, the <c>edit</c> is applied first, then the <c>command</c> is executed.
    /// </para>
    /// </remarks>
    /// <seealso>Spec 3.8.0</seealso>
    public class CodeAction(string title)
    {
        public class Disabled(string reason)
        {
            /// <summary>
            /// Human readable description of why the code action is currently disabled.
            /// 
            /// This is displayed in the code actions UI.
            /// </summary>
            public string reason = reason;
        }
        /// <summary>
        /// A short, human-readable, title for this code action.
        /// </summary>
        /// <seealso>Spec 3.8.0</seealso>
        public string title = title;

        /// <summary>
        /// The kind of the code action.
        /// </summary>
        /// <remarks>
        /// Used to filter code actions.
        /// </remarks>
        /// <value>
        /// See <see cref="CodeActionKind"/> for an enumeration of standardized kinds.
        /// </value>
        /// <seealso cref="CodeActionKind"/>
        /// <seealso>Spec 3.8.0</seealso>
        public string? kind;

        /// <summary>
        /// 此代码操作解析的诊断。
        /// </summary>
        /// <seealso>Spec 3.8.0</seealso>
        public Diagnostic[]? diagnostics;

        /// <summary>
        /// 将此标记为首选操作。首选操作由`auto fix`命令使用，并且可以通过键绑定来定位。
        /// 
        /// 如果快速修复可以正确解决底层错误，则应标记为首选。
        /// 如果重构是最合理的操作选择，那么应该标记为首选。
        /// </summary>
        /// <seealso>Spec 3.15.0</seealso>
        public bool? isPreferred;

        /// <summary>
        /// 标记当前不能应用代码操作。
        /// 
        /// 客户端应该遵循以下关于禁用代码操作的指导方针：
        /// - 禁用的代码操作不会显示在自动灯泡代码操作菜单中。
        /// - 当用户请求更特定类型的代码操作（如重构）时，禁用的操作在代码操作菜单中显示为淡出。
        /// - 如果用户有一个自动应用代码操作的键绑定，并且只返回一个禁用的代码操作，客户端应该在编辑器中向用户显示一个带有“reason”的错误消息。
        /// </summary>
        /// <seealso>Spec 3.16.0</seealso>
        public Disabled? disabled;

        /// <summary>
        /// The workspace edit this code action performs.
        /// </summary>
        /// <seealso>Spec 3.8.0</seealso>
        public WorkspaceEdit? edit;

        /// <summary>
        /// A command this code action executes.
        /// </summary>
        /// <remarks>
        /// If a code action provides an edit and a command, first the edit is executed and then the command.
        /// </remarks>
        /// <seealso>Spec 3.8.0</seealso>
        public Command? command;

        /// <summary>
        /// A data entry field that is preserved on a code action between
        /// a `textDocument/codeAction` and a `codeAction/resolve` request.
        /// </summary>
        /// <seealso>Spec 3.16.0</seealso>
        public dynamic? data;
    }
}
