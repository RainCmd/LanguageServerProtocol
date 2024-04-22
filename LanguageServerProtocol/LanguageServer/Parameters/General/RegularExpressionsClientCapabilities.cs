namespace LanguageServer.Parameters.General
{
    /// <summary>
    /// 特定于正则表达式的客户端功能。
    /// </summary>
    /// <param name="engine"></param>
    /// <param name="version"></param>
    public class RegularExpressionsClientCapabilities(string engine, string? version)
    {
        /// <summary>
        /// 引擎的名称。
        /// </summary>
        public readonly string engine = engine;
        /// <summary>
        /// The engine's version.
        /// </summary>
        public readonly string? version = version;
    }
}