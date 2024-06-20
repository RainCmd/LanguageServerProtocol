namespace LanguageServer.Parameters.General
{
    public static class PositionEncodingKind
    {
        /// <summary>
        /// Character offsets count UTF-8 code units (e.g bytes).
        /// </summary>
        public const string UTF8 = "utf-8";
        /// <summary>
        /// Character offsets count UTF-16 code units.
        /// </summary>
        /// <remarks>
        /// 这是默认值，服务器必须始终支持它
        /// </remarks>
        public const string UTF16 = "utf-16";
        /// <summary>
        /// Character offsets count UTF-32 code units.
        /// </summary>
        /// <remarks>
        /// 实现注意:这些与Unicode码位相同，所以这个' PositionEncodingKind '也可以用于字符偏移的编码无关表示。
        /// </remarks>
        public const string UTF32 = "utf-32";
    }
}
