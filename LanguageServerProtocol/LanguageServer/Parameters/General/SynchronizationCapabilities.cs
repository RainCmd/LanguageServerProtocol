namespace LanguageServer.Parameters.General
{
    /// <summary>
    /// For <c>initialize</c>
    /// </summary>
    public class SynchronizationCapabilities : RegistrationCapabilities
    {
        /// <summary>
        /// 客户端支持发送将保存通知。
        /// </summary>
        public bool willSave;

        /// <summary>
        /// 客户端支持发送将保存请求，并等待提供文本编辑的响应，该响应将在保存之前应用于文档。
        /// </summary>
        public bool willSaveWaitUntil;

        /// <summary>
        /// 客户端支持保存通知。
        /// </summary>
        public bool didSave;
    }
}
