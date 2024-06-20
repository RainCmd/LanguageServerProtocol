using LanguageServer.Parameters.Workspace;

namespace LanguageServer.Client
{
    /// <summary>
    /// 用于发送与工作空间相关的消息的代理类。
    /// </summary>
    public class WorkspaceProxy(Proxy proxy)
    {
        /// <summary>
        /// workspace/applyEdit
        /// 请求从服务器发送到客户端，以修改客户端的资源。
        /// </summary>
        /// <returns></returns>
        public Task<ApplyWorkspaceEditResponse> ApplyEdit(ApplyWorkspaceEditParams param)
        {
            return proxy.SendRequest<ApplyWorkspaceEditParams, ApplyWorkspaceEditResponse>("workspace/applyEdit", param);
        }

        /// <summary>
        /// workspace/workspaceFolders
        /// 请求从服务器发送到客户端，以获取当前打开的工作空间文件夹列表。
        /// </summary>
        /// <returns>
        /// 如果在工具中只打开了一个文件，则返回 null。
        /// 如果工作空间已打开，但未配置任何文件夹，则返回空数组。
        /// </returns>
        /// <seealso>Spec 3.6.0</seealso>
        public Task<WorkspaceFolder[]> WorkspaceFolders()
        {
            return proxy.SendRequest<WorkspaceFolder[]>("workspace/workspaceFolders");
        }

        /// <summary>
        /// workspace/configuration
        /// 请求从服务器发送到客户端，以从客户端获取配置设置。
        /// 请求可以在一次往返中获取n个配置设置。
        /// </summary>
        /// <param name="param">要求的配置部分</param>
        /// <returns>配置设置</returns>
        /// <seealso>Spec 3.6.0</seealso>
        public Task<dynamic[]> Configuration(ConfigurationParams param)
        {
            return proxy.SendRequest<ConfigurationParams, dynamic[]>("workspace/configuration", param);
        }
    }
}
