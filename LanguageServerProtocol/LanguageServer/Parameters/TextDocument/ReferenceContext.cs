namespace LanguageServer.Parameters.TextDocument
{
    public class ReferenceContext(bool includeDeclaration)
    {
        /// <summary>
        /// 包括当前符号的声明。
        /// </summary>
        public bool includeDeclaration = includeDeclaration;
    }
}
