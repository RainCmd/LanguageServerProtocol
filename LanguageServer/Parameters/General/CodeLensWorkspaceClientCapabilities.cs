namespace LanguageServer.Parameters.General
{
    /// <summary>
    /// `workspace/codeLens/refresh` 请求从服务器发送到客户端。
    /// 服务器可以使用它来请求客户端刷新当前显示在编辑器中的代码镜头。
    /// 因此，客户机应该请求服务器为这些编辑器重新计算代码透镜。
    /// 如果服务器检测到需要重新计算所有代码镜片的配置更改，这将非常有用。
    /// 请注意，如果编辑器当前不可见，客户端仍然有延迟代码透镜重新计算的自由。
    /// </summary>
    public class CodeLensWorkspaceClientCapabilities
    {
        /// <summary>
        /// 客户端实现是否支持从服务器发送到客户端的刷新请求。
        /// 
        /// 请注意，此事件是全局的，将强制客户端刷新当前显示的所有代码镜头。
        /// 它应该非常小心地使用，并且对于服务器（例如检测需要这种计算的项目范围的更改）的情况非常有用。
        /// </summary>
        public bool? refreshSupport;
    }
}
