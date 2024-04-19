namespace LanguageServer.Parameters.General
{
    /// <summary>
    /// For <c>initialize</c>
    /// </summary>
    public class EditCapabilities
    {
        /// <summary>
        /// 客户端支持在 WorkspaceEdit 中进行版本化文档更改
        /// </summary>
        public bool documentChanges;
    }
}
