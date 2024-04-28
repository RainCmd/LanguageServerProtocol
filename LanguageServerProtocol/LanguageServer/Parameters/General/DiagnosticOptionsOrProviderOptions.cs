using LanguageServer.Json;

namespace LanguageServer.Parameters.General
{
    /// <summary>
    /// <see cref="General.ProviderOptions"/> | <see cref="General.DiagnosticOptions"/>
    /// </summary>
    public class DiagnosticOptionsOrProviderOptions : Either
    {
        public bool IsProviderOptions => type == typeof(ProviderOptions);
        public ProviderOptions ProviderOptions => (ProviderOptions)value;
        public bool IsDiagnosticOptions => type == typeof(DiagnosticOptions);
        public DiagnosticOptions DiagnosticOptions => (DiagnosticOptions)value;
        public DiagnosticOptionsOrProviderOptions(ProviderOptions value) : base(value, typeof(ProviderOptions)) { }
        public DiagnosticOptionsOrProviderOptions(DiagnosticOptions value) : base(value, typeof(DiagnosticOptions)) { }
    }
}
