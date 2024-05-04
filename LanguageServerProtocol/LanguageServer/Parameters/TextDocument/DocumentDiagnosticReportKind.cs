namespace LanguageServer.Parameters.TextDocument
{
    /// <summary>
    /// The document diagnostic report kinds.
    /// </summary>
    public static class DocumentDiagnosticReportKind
    {
        /// <summary>
        /// 包含全套问题的诊断报告。
        /// </summary>
        public const string Full = "full";
        /// <summary>
        /// 表明最后返回的报告仍然准确的报告。
        /// </summary>
        public const string Unchanged = "unchanged";
    }
}
