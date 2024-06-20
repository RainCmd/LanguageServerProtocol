namespace LanguageServer.Parameters.Workspace
{
    /// <summary>
    /// For <c>workspace/symbol</c>
    /// </summary>
    public class WorkspaceSymbolParams(string query)
    {
        /// <summary>
        /// 要过滤符号的查询字符串。客户端可以在这里发送一个空字符串来请求所有符号。
        /// </summary>
        public string query = query;
    }
}
