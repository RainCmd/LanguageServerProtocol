namespace LanguageServer.Parameters.General
{
    public class ResolveSupport(string[] properties)
    {
        /// <summary>
        /// 客户端可以惰性解析的属性。
        /// </summary>
        public string[] properties = properties;
    }
}