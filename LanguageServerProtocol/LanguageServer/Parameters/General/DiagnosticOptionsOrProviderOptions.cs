using LanguageServer.Json;

namespace LanguageServer.Parameters.General
{
    /// <summary>
    /// <see cref="ProviderOptions"/> | <see cref="DiagnosticOptions"/>
    /// </summary>
    public class DiagnosticOptionsOrProviderOptions : Either<ProviderOptions, DiagnosticOptions>
    {
        public DiagnosticOptionsOrProviderOptions(ProviderOptions value) : base(value) { }
        public DiagnosticOptionsOrProviderOptions(DiagnosticOptions value) : base(value) { }
        public static implicit operator DiagnosticOptionsOrProviderOptions(ProviderOptions value) => new(value);
        public static implicit operator DiagnosticOptionsOrProviderOptions(DiagnosticOptions value) => new(value);
    }
}
