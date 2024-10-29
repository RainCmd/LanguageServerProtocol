namespace LanguageServer.Parameters.TextDocument
{
    public class CallHierarchyIncomingCall(CallHierarchyItem from, Range[] fromRanges)
    {
        /// <summary>
        /// 发出呼叫的项。
        /// </summary>
        public CallHierarchyItem from = from;
        /// <summary>
        /// 呼叫出现的范围。这是相对于调用者表示的<see cref="from"/>。
        /// </summary>
        public Range[] fromRanges = fromRanges;
    }
}
