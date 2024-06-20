namespace LanguageServer.Parameters.General
{
    /// <summary>
    /// For <c>initialize</c>
    /// </summary>
    /// <seealso>Spec 3.6.0</seealso>
    public class WorkspaceFoldersOptions
    {
        /// <summary>
        /// 服务器支持工作空间文件夹
        /// </summary>
        /// <seealso>Spec 3.6.0</seealso>
        public bool? supported;

        /// <summary>
        /// 服务器是否希望接收工作区文件夹更改通知。
        /// </summary>
        /// <remarks>
        /// 如果提供了字符串，则将该字符串视为在客户端注册通知的ID。
        /// 该ID可用于使用<c>client/unregisterCapability</c>请求取消这些事件的注册。
        /// </remarks>
        /// <seealso>Spec 3.6.0</seealso>
        public ChangeNotificationsOptions? changeNotifications;
    }
}
