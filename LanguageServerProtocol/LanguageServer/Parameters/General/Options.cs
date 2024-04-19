namespace LanguageServer.Parameters.General
{
    /// <summary>
    /// For <c>initialize</c>
    /// </summary>
    /// <remarks>
    /// 定义每个通知的详细结构。
    /// </remarks>
    public class TextDocumentSyncOptions
    {
        /// <summary>
        /// 打开和关闭通知被发送到服务器。
        /// </summary>
        public bool openClose;
        /// <summary>
        /// 更改通知被发送到服务器。
        /// </summary>
        public TextDocumentSyncKind change;
        /// <summary>
        /// 将保存通知发送到服务器。
        /// </summary>
        public bool? willSave;
        /// <summary>
        /// 将保存等待，直到请求被发送到服务器。
        /// </summary>
        public bool? willSaveWaitUntil;
        /// <summary>
        /// 保存通知被发送到服务器。
        /// </summary>
        public SaveOptions? save;
    }

    /// <summary>
    /// For <c>initialize</c>
    /// </summary>
    /// <remarks>
    /// 保存选项
    /// </remarks>
    public class SaveOptions
    {
        /// <summary>
        /// 客户端应该在保存时包含内容。
        /// </summary>
        public bool includeText;
    }

    /// <summary>
    /// For <c>initialize</c>
    /// </summary>
    /// <remarks>
    /// 补全选项
    /// </remarks>
    public class CompletionOptions
    {
        /// <summary>
        /// 服务器提供解析补全项的附加信息的支持。
        /// </summary>
        public bool resolveProvider;

        /// <summary>
        /// 自动触发补全的字符。
        /// </summary>
        public string[]? triggerCharacters;
    }

    /// <summary>
    /// For <c>initialize</c>
    /// </summary>
    /// <remarks>
    /// 签名帮助选项。
    /// </remarks>
    public class SignatureHelpOptions
    {
        /// <summary>
        /// 触发签名的字符自动帮助。
        /// </summary>
        public string[]? triggerCharacters;
    }

    /// <summary>
    /// For <c>initialize</c>
    /// </summary>
    /// <remarks>
    /// Code Lens options.
    /// </remarks>
    public class CodeLensOptions
    {
        /// <summary>
        /// Code lens也有一个解析提供程序。
        /// </summary>
        public bool resolveProvider;
    }

    /// <summary>
    /// For <c>initialize</c>
    /// </summary>
    /// <remarks>
    /// 按类型选项格式化文档。
    /// </remarks>
    public class DocumentOnTypeFormattingOptions
    {
        /// <summary>
        /// 应该在其上触发格式化的字符，如“}”。
        /// </summary>
        public string? firstTriggerCharacter;

        /// <summary>
        /// 更多触发字符。
        /// </summary>
        public string[]? moreTriggerCharacter;
    }

    /// <summary>
    /// For <c>initialize</c>
    /// </summary>
    /// <remarks>
    /// Document link options.
    /// </remarks>
    public class DocumentLinkOptions
    {
        /// <summary>
        /// 文档链接也有一个解析提供程序。
        /// </summary>
        public bool resolveProvider;
    }

    /// <summary>
    /// For <c>initialize</c>
    /// </summary>
    /// <remarks>
    /// Execute command options.
    /// </remarks>
    public class ExecuteCommandOptions
    {
        /// <summary>
        /// 需要在服务器上执行的命令
        /// </summary>
        public string[]? commands;
    }
}
