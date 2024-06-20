namespace LanguageServer.Parameters.General
{
    /// <summary>
    /// 在插入补全项时如何处理空白和缩进。
    /// </summary>
    public class InsertTextMode
    {
        /// <summary>
        /// 插入或替换字符串按原样处理。如果值是多行，将使用字符串值中定义的缩进插入光标下面的行。
        /// 客户端不会对字符串进行任何类型的调整。
        /// </summary>
        public const int asIs = 1;
        /// <summary>
        /// 编辑器调整新行的前导空白，使它们与接受该项的行光标的缩进匹配。
        /// 
        /// 考虑这样一行:<2tabs><cursor><3tabs>foo。接受多行完成项使用2个制表符缩进，并且插入的所有后续行也将使用2个制表符缩进。
        /// </summary>
        public const int adjustIndentation = 2;
    }
}