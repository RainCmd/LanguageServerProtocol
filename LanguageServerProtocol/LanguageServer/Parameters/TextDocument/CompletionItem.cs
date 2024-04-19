namespace LanguageServer.Parameters.TextDocument
{
    /// <summary>
    /// For <c>textDocument/completion</c> and <c>completionItem/resolve</c>
    /// </summary>
    /// <seealso>Spec 3.9.0</seealso>
    public class CompletionItem(string label)
    {
        /// <summary>
        /// 此完成项的标签。
        /// </summary>
        public string label = label;

        /// <summary>
        /// 此完成项的类型。
        /// </summary>
        public CompletionItemKind? kind;

        /// <summary>
        /// 一个人类可读的字符串，包含关于该项的附加信息，如类型或符号信息。
        /// </summary>
        public string? detail;

        /// <summary>
        /// 一个人类可读的字符串，表示文档注释。
        /// </summary>
        /// <seealso>Spec 3.3.0</seealso>
        public Documentation? documentation;

        /// <summary>
        /// 指示该项是否已弃用。
        /// </summary>
        /// <seealso>Spec 3.7.2</seealso>
        public bool? deprecated;

        /// <summary>
        /// 显示时选择此项目。
        /// </summary>
        /// <remarks>
        /// 请注意，只能选择一个完成项，并且由工具/客户端决定是哪个项。
        /// 规则是选择最匹配的第一个项。
        /// </remarks>
        /// <seealso>Spec 3.9.0</seealso>
        public bool? preselect;

        /// <summary>
        /// 将此项与其他项进行比较时应使用的字符串。
        /// </summary>
        public string? sortText;

        /// <summary>
        /// 在过滤一组补全项时应使用的字符串。
        /// </summary>
        public string? filterText;

        /// <summary>
        /// 选择此补全时应插入文档中的字符串。
        /// </summary>
        /// <seealso>Spec 3.3.0</seealso>
        [Obsolete("自规范v3.3.0以来，insertText已弃用，请使用textEdit代替。")]
        public string? insertText;

        /// <summary>
        /// 插入文本的格式。
        /// </summary>
        public InsertTextFormat? insertTextFormat;

        /// <summary>
        /// 选择此补全时应用于文档的编辑。
        /// </summary>
        public TextEdit? textEdit;

        /// <summary>
        /// 选择此补全时应用的附加文本编辑的可选数组。
        /// </summary>
        public TextEdit[]? additionalTextEdits;

        /// <summary>
        /// 一组可选的字符，在激活此补全功能时按下该字符，将首先接受该字符，然后键入该字符。
        /// </summary>
        /// <remarks>
        /// 注意，所有提交字符的长度都应该是1，多余的字符将被忽略。
        /// </remarks>
        /// <seealso>Spec 3.2.0</seealso>
        public string[]? commitCharacters;

        /// <summary>
        /// 一个可选命令，在插入此补全后执行。
        /// </summary>
        public Command? command;

        /// <summary>
        /// 保存在补全请求和补全解析请求之间的补全项上的数据输入字段。
        /// </summary>
        public dynamic? data;
    }
}
