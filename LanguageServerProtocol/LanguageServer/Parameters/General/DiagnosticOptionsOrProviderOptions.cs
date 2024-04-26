using LanguageServer.Json;

namespace LanguageServer.Parameters.General
{
    public class DiagnosticOptionsOrProviderOptions : Either
    {
        public bool IsProviderOptions => Type == typeof(ProviderOptions);
        public ProviderOptions ProviderOptions => GetValue<ProviderOptions>();
        public bool IsDiagnosticOptions => Type == typeof(DiagnosticOptions);
        public DiagnosticOptions DiagnosticOptions => GetValue<DiagnosticOptions>();
        public DiagnosticOptionsOrProviderOptions(ProviderOptions value) : base(value, typeof(ProviderOptions)) { }
        public DiagnosticOptionsOrProviderOptions(DiagnosticOptions value) : base(value, typeof(DiagnosticOptions)) { }
    }
}
