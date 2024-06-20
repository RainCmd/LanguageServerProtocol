namespace LanguageServer.Parameters.General
{
    /// <summary>
    /// For <c>initialize</c>
    /// </summary>
    public class InitializeErrorData(bool retry)
    {
        /// <summary>
        /// 指示客户端是否执行以下重试逻辑。
        /// </summary>
        /// <remarks>
        /// <list type="number">
        /// <item><description>show the message provided by the <c>ResponseError</c> to the user</description></item>
        /// <item><description>user selects retry or cancel</description></item>
        /// <item><description>if user selected retry the initialize method is sent again</description></item>
        /// </list>
        /// </remarks>
        public bool retry = retry;
    }
}
