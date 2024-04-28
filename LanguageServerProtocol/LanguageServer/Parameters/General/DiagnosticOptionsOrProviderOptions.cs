﻿using LanguageServer.Json;

namespace LanguageServer.Parameters.General
{
    /// <summary>
    /// <see cref="General.ProviderOptions"/> | <see cref="General.DiagnosticOptions"/>
    /// </summary>
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