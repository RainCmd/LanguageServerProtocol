namespace LanguageServer.Json
{
    public sealed class NumberOrString : EquatableEither<long, string>
    {
        public NumberOrString(long value) : base(value) { }
        public NumberOrString(string value) : base(value) { }
        public static implicit operator NumberOrString(long value) => new(value);
        public static implicit operator NumberOrString(string value) => new(value);
    }
}
