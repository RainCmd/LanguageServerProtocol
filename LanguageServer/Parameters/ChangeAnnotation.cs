namespace LanguageServer.Parameters
{
    /// <summary>
    /// 描述文档更改的附加信息。
    /// </summary>
    /// <param name="label"></param>
    public class ChangeAnnotation(string label)
    {
        /// <summary>
        /// 描述实际更改的可读字符串。该字符串将在用户界面中突出显示。
        /// </summary>
        public readonly string label = label;
        /// <summary>
        /// 一个标志，指示在应用更改之前需要用户确认。
        /// </summary>
        public readonly bool? needsConfirmation;
        /// <summary>
        /// 一个人类可读的字符串，在用户界面中呈现得不那么突出。
        /// </summary>
        public readonly string? description;
    }
}