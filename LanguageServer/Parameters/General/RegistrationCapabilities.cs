namespace LanguageServer.Parameters.General
{
    /// <summary>
    /// For <c>initialize</c>
    /// </summary>
    public class RegistrationCapabilities
    {
        /// <summary>
        /// 客户端是否支持动态注册。
        /// </summary>
        public bool dynamicRegistration;
        /// <summary>
        /// 客户端支持在执行重命名操作之前测试重命名操作的有效性。
        /// </summary>
        /// <remarks>@since version 3.12.0</remarks>
        public bool? prepareSupport;
        /// <summary>
        /// 客户端是否遵守通过重命名请求的工作区编辑返回的文本编辑和资源操作中的更改注释，例如在用户界面中显示工作区编辑并请求确认。
        /// </summary>
        /// <remarks>@since 3.16.0</remarks>
        public bool? honorsChangeAnnotations;
    }
}
