namespace LanguageServer.Parameters.TextDocument
{
    public class CallHierarchyOutgoingCall(CallHierarchyItem to, Range[] fromRanges)
    {
        /// <summary>
        /// The item that is called.
        /// </summary>
        public CallHierarchyItem to = to;
        /// <summary>
        /// 调用该项的范围。这是相对于调用者的范围，例如传递给`callHierarchy/outgoingCalls`请求的项。
        /// </summary>
        public Range[] fromRanges = fromRanges;
    }
}
