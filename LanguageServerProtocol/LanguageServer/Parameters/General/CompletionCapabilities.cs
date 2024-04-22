using LanguageServer.Parameters.TextDocument;

namespace LanguageServer.Parameters.General
{
    /// <summary>
    /// For <c>initialize</c>
    /// </summary>
    /// <seealso>Spec 3.4.0</seealso>
    public class CompletionCapabilities : RegistrationCapabilities
    {
        /// <summary>
        /// The client supports the following <c>CompletionItem</c> specific capabilities.
        /// </summary>
        public CompletionItemCapabilities? completionItem;

        /// <summary>
        /// The completion item kind values the client supports.
        /// </summary>
        /// <seealso>Spec 3.4.0</seealso>
        public CompletionItemKindCapabilities? completionItemKind;

        /// <summary>
        /// The client supports to send additional context information for a
        /// <c>textDocument/completion</c> request.
        /// </summary>
        /// <seealso>Spec 3.3.0</seealso>
        public bool? contextSupport;

        /// <summary>
        /// 当完成项没有提供' insertTextMode '属性时，这是客户端的默认值。
        /// <see cref="InsertTextMode"/>
        /// </summary>
        public int? insertTextMode;

        /// <summary>
        /// 客户端支持以下“CompletionList”特定功能。
        /// </summary>
        public CompletionListCapabilities? completionList;
    }
}
