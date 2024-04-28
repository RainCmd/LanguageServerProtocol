namespace LanguageServer.Json
{
    public sealed class NumberOrString : Either, IEquatable<NumberOrString>
    {
        public NumberOrString(long value) : base(value, typeof(long)) { }

        public NumberOrString(string value) : base(value, typeof(string)) { }

        public bool IsLeft => type == typeof(long);

        public bool IsRight => type == typeof(string);

        public long Left => (long)value;

        public string Right => (string)value;

        public override int GetHashCode() => IsLeft ? Left.GetHashCode() : IsRight ? Right.GetHashCode() : 0;

        public override bool Equals(object? obj) => obj is NumberOrString other && Equals(other);

        public bool Equals(NumberOrString? other)
        {
            if (other == null) return false;
            if (IsLeft && other.IsLeft) return Left == other.Left;
            if (IsRight && other.IsRight) return Right == other.Right;
            return !IsLeft && !IsRight && !other.IsLeft && !other.IsRight; // None == None
        }

        public static implicit operator NumberOrString(long value) => new(value);

        public static implicit operator NumberOrString(string value) => new(value);
    }
}
