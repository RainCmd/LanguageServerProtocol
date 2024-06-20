namespace LanguageServer.Parameters.TextDocument
{
    /// <summary>
    /// 表示对命令的引用。提供一个标题，该标题将用于表示UI中的命令。命令由字符串标识符标识。
    /// 处理命令的推荐方法是，如果客户机和服务器提供相应的功能，则在服务器端实现它们的执行。
    /// 或者，工具扩展代码可以处理该命令。该协议目前没有指定一组众所周知的命令。
    /// </summary>
    public class Command(string title, string command)
    {
        /// <summary>
        /// 命令的标题，如“save”
        /// </summary>
        public string title = title;

        /// <summary>
        /// 实际命令处理程序的标识符。
        /// </summary>
        public string command = command;

        /// <summary>
        /// 应该调用命令处理程序的参数。
        /// </summary>
        public dynamic[]? arguments;
    }
}
