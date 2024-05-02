using LanguageServer.Parameters.Client;

namespace LanguageServer.Client
{
    /// <summary>
    /// 用于发送与客户端相关的消息的代理类。
    /// </summary>
    public sealed class ClientProxy(Proxy proxy)
    {
        /// <summary>
        /// The <c>client/registerCapability</c> request is sent from the server to the client
        /// to register for a new capability on the client side.
        /// client/registerCapability
        /// 请求从服务器发送到客户端，以在客户端注册新功能。
        /// </summary>
        /// <param name="params"></param>
        /// <returns></returns>
        public Task RegisterCapability(RegistrationParams param)
        {
            return proxy.SendRequest("client/registerCapability", param);
        }

        /// <summary>
        /// client/unregisterCapability
        /// 请求从服务器发送到客户端，取消先前注册的功能。
        /// </summary>
        /// <param name="params"></param>
        /// <returns></returns>
        public Task UnregisterCapability(UnregistrationParams param)
        {
            return proxy.SendRequest("client/unregisterCapability", param);
        }
    }
}
