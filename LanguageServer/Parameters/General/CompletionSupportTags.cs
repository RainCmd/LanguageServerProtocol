namespace LanguageServer.Parameters.General
{
    public class CompletionSupportTags(int[] valueSet)
    {
        /// <summary>
        /// 客户端支持的标记。<see cref="CompletionItemTag"/>
        /// </summary>
        public int[] valueSet = valueSet;
    }
}
