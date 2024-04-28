namespace LanguageServer.Parameters.Workspace
{
    public class ExecuteCommandParams(string command)
    {
        /// <summary>
        /// 实际命令处理程序的标识符。
        /// </summary>
        public string command = command;
        /// <summary>
        /// 调用命令时应使用的参数。
        /// </summary>
        public dynamic[]? arguments;
    }
}
