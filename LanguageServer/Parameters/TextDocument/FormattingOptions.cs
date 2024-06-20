namespace LanguageServer.Parameters.TextDocument
{
    public class FormattingOptions
    {
        /// <summary>
        /// 空格中标签的大小。
        /// </summary>
        public int tabSize;

        /// <summary>
        /// 选择空格而不是制表符。
        /// </summary>
        public bool insertSpaces;

        /// <summary>
        /// 修整一行上的尾随空白。
        /// </summary>
        public bool? trimTrailingWhitespace;

        /// <summary>
        /// 如果在文件末尾不存在换行符，请插入换行符。
        /// </summary>
        public bool? insertFinalNewline;

        /// <summary>
        /// 裁剪文件末尾最后一个换行符之后的所有换行符。
        /// </summary>
        public bool? trimFinalNewlines;

        // 进一步属性的签名。
        // [key: string]: boolean | number | string;
    }
}
