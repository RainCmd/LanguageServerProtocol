namespace LanguageServer.Json
{
    /// <summary>
    /// Mimic discriminated union types
    /// </summary>
    /// <remarks>
    /// <see cref="Serializer"/> must support these derived types below:
    /// 必须支持下列派生类型:
    /// <list type="bullet">
    /// <item><see cref="Parameters.General.ChangeNotificationsOptions"/></item>
    /// <item><see cref="Parameters.TextDocument.CodeActionResult"/></item>
    /// <item><see cref="Parameters.General.ColorProviderOptionsOrBoolean"/></item>
    /// <item><see cref="Parameters.TextDocument.CompletionResult"/></item>
    /// <item><see cref="Parameters.General.DiagnosticOptionsOrProviderOptions"/></item>
    /// <item><see cref="Parameters.TextDocument.Documentation"/></item>
    /// <item><see cref="Parameters.TextDocument.DocumentSymbolResult"/></item>
    /// <item><see cref="Parameters.General.FoldingRangeProviderOptionsOrBoolean"/></item>
    /// <item><see cref="Parameters.TextDocument.HoverContents"/></item>
    /// <item><see cref="Parameters.LocationSingleOrArray"/></item>
    /// <item><see cref="NumberOrString"/></item>
    /// <item><see cref="Parameters.General.ProviderOptionsOrBoolean"/></item>
    /// <item><see cref="Parameters.TextDocument.TextDocumentContentChangeEvent"/></item>
    /// <item><see cref="Parameters.General.TextDocumentSync"/></item>
    /// <item><see cref="Parameters.TextDocument.TextEditOrInsertReplaceEdit"/></item>
    /// </list>
    /// </remarks>
    public abstract class Either(object value, Type type)
    {
        public object value = value;
        public Type type = type;
        public override string? ToString()
        {
            return value.ToString();
        }
    }
    public class Either<T1, T2> : Either where T1 : notnull where T2 : notnull
    {
        public Either(T1 value) : base(value, typeof(T1)) { }
        public Either(T2 value) : base(value, typeof(T2)) { }
        public bool IsFirst => typeof(T1) == type;
        public T1 First => (T1)value;
        public bool IsSecond => typeof(T2) == type;
        public T2 Second => (T2)value;
        public static implicit operator Either<T1, T2>(T1 value) => new(value);
        public static implicit operator Either<T1, T2>(T2 value) => new(value);
        public static implicit operator T1(Either<T1, T2> value) => value.First;
        public static implicit operator T2(Either<T1, T2> value) => value.Second;
    }
    public class Either<T1, T2, T3> : Either where T1 : notnull where T2 : notnull where T3 : notnull
    {
        public Either(T1 value) : base(value, typeof(T1)) { }
        public Either(T2 value) : base(value, typeof(T2)) { }
        public Either(T3 value) : base(value, typeof(T3)) { }
        public bool IsFirst => typeof(T1) == type;
        public T1 First => (T1)value;
        public bool IsSecond => typeof(T2) == type;
        public T2 Second => (T2)value;
        public bool IsThird => typeof(T3) == type;
        public T3 Third => (T3)value;
        public static implicit operator Either<T1, T2, T3>(T1 value) => new(value);
        public static implicit operator Either<T1, T2, T3>(T2 value) => new(value);
        public static implicit operator Either<T1, T2, T3>(T3 value) => new(value);
        public static implicit operator T1(Either<T1, T2, T3> value) => value.First;
        public static implicit operator T2(Either<T1, T2, T3> value) => value.Second;
        public static implicit operator T3(Either<T1, T2, T3> value) => value.Third;
    }
    public class Either<T1, T2, T3, T4> : Either where T1 : notnull where T2 : notnull where T3 : notnull where T4 : notnull
    {
        public Either(T1 value) : base(value, typeof(T1)) { }
        public Either(T2 value) : base(value, typeof(T2)) { }
        public Either(T3 value) : base(value, typeof(T3)) { }
        public Either(T4 value) : base(value, typeof(T4)) { }
        public bool IsFirst => typeof(T1) == type;
        public T1 First => (T1)value;
        public bool IsSecond => typeof(T2) == type;
        public T2 Second => (T2)value;
        public bool IsThird => typeof(T3) == type;
        public T3 Third => (T3)value;
        public bool IsFourth => typeof(T4) == type;
        public T4 Fourth => (T4)value;
        public static implicit operator Either<T1, T2, T3, T4>(T1 value) => new(value);
        public static implicit operator Either<T1, T2, T3, T4>(T2 value) => new(value);
        public static implicit operator Either<T1, T2, T3, T4>(T3 value) => new(value);
        public static implicit operator Either<T1, T2, T3, T4>(T4 value) => new(value);
        public static implicit operator T1(Either<T1, T2, T3, T4> value) => value.First;
        public static implicit operator T2(Either<T1, T2, T3, T4> value) => value.Second;
        public static implicit operator T3(Either<T1, T2, T3, T4> value) => value.Third;
        public static implicit operator T4(Either<T1, T2, T3, T4> value) => value.Fourth;
    }
    public class EquatableEither<T1, T2> : Either, IEquatable<EquatableEither<T1, T2>> where T1 : notnull, IEquatable<T1> where T2 : notnull, IEquatable<T2>
    {
        public EquatableEither(T1 value) : base(value, typeof(T1)) { }
        public EquatableEither(T2 value) : base(value, typeof(T2)) { }
        public bool IsFirst => typeof(T1) == type;
        public T1 First => (T1)value;
        public bool IsSecond => typeof(T2) == type;
        public T2 Second => (T2)value;
        public override int GetHashCode() => IsFirst ? First.GetHashCode() : IsSecond ? Second.GetHashCode() : 0;
        public override bool Equals(object? obj) => obj is EquatableEither<T1, T2> other && Equals(other);
        public bool Equals(EquatableEither<T1, T2>? other)
        {
            if (other == null) return false;
            if (IsFirst && other.IsFirst) return First.Equals(other.First);
            else if (IsSecond && other.IsSecond) return Second.Equals(other.Second);
            return false;
        }

        public static implicit operator EquatableEither<T1, T2>(T1 value) => new(value);
        public static implicit operator EquatableEither<T1, T2>(T2 value) => new(value);
        public static implicit operator T1(EquatableEither<T1, T2> value) => value.First;
        public static implicit operator T2(EquatableEither<T1, T2> value) => value.Second;
    }
    public class EquatableEither<T1, T2, T3> : Either, IEquatable<EquatableEither<T1, T2, T3>> where T1 : notnull, IEquatable<T1> where T2 : notnull, IEquatable<T2> where T3 : notnull, IEquatable<T3>
    {
        public EquatableEither(T1 value) : base(value, typeof(T1)) { }
        public EquatableEither(T2 value) : base(value, typeof(T2)) { }
        public EquatableEither(T3 value) : base(value, typeof(T3)) { }
        public bool IsFirst => typeof(T1) == type;
        public T1 First => (T1)value;
        public bool IsSecond => typeof(T2) == type;
        public T2 Second => (T2)value;
        public bool IsThird => typeof(T3) == type;
        public T3 Third => (T3)value;
        public override int GetHashCode() => IsFirst ? First.GetHashCode() : IsSecond ? Second.GetHashCode() : IsThird ? Third.GetHashCode() : 0;
        public override bool Equals(object? obj) => obj is EquatableEither<T1, T2, T3> other && Equals(other);
        public bool Equals(EquatableEither<T1, T2, T3>? other)
        {
            if (other == null) return false;
            if (IsFirst && other.IsFirst) return First.Equals(other.First);
            else if (IsSecond && other.IsSecond) return Second.Equals(other.Second);
            else if (IsThird && other.IsThird) return Third.Equals(other.Third);
            return false;
        }
        public static implicit operator EquatableEither<T1, T2, T3>(T1 value) => new(value);
        public static implicit operator EquatableEither<T1, T2, T3>(T2 value) => new(value);
        public static implicit operator EquatableEither<T1, T2, T3>(T3 value) => new(value);
        public static implicit operator T1(EquatableEither<T1, T2, T3> value) => value.First;
        public static implicit operator T2(EquatableEither<T1, T2, T3> value) => value.Second;
        public static implicit operator T3(EquatableEither<T1, T2, T3> value) => value.Third;
    }
    public class EquatableEither<T1, T2, T3, T4> : Either, IEquatable<EquatableEither<T1, T2, T3, T4>> where T1 : notnull, IEquatable<T1> where T2 : notnull, IEquatable<T2> where T3 : notnull, IEquatable<T3> where T4 : notnull, IEquatable<T4>
    {
        public EquatableEither(T1 value) : base(value, typeof(T1)) { }
        public EquatableEither(T2 value) : base(value, typeof(T2)) { }
        public EquatableEither(T3 value) : base(value, typeof(T3)) { }
        public EquatableEither(T4 value) : base(value, typeof(T4)) { }
        public bool IsFirst => typeof(T1) == type;
        public T1 First => (T1)value;
        public bool IsSecond => typeof(T2) == type;
        public T2 Second => (T2)value;
        public bool IsThird => typeof(T3) == type;
        public T3 Third => (T3)value;
        public bool IsFourth => typeof(T4) == type;
        public T4 Fourth => (T4)value;
        public override int GetHashCode() => IsFirst ? First.GetHashCode() : IsSecond ? Second.GetHashCode() : IsThird ? Third.GetHashCode() : IsFourth ? Fourth.GetHashCode() : 0;
        public override bool Equals(object? obj) => obj is EquatableEither<T1, T2, T3, T4> other && Equals(other);
        public bool Equals(EquatableEither<T1, T2, T3, T4>? other)
        {
            if (other == null) return false;
            if (IsFirst && other.IsFirst) return First.Equals(other.First);
            else if (IsSecond && other.IsSecond) return Second.Equals(other.Second);
            else if (IsThird && other.IsThird) return Third.Equals(other.Third);
            else if (IsFourth && other.IsFourth) return Fourth.Equals(other.Fourth);
            return false;
        }
        public static implicit operator EquatableEither<T1, T2, T3, T4>(T1 value) => new(value);
        public static implicit operator EquatableEither<T1, T2, T3, T4>(T2 value) => new(value);
        public static implicit operator EquatableEither<T1, T2, T3, T4>(T3 value) => new(value);
        public static implicit operator EquatableEither<T1, T2, T3, T4>(T4 value) => new(value);
        public static implicit operator T1(EquatableEither<T1, T2, T3, T4> value) => value.First;
        public static implicit operator T2(EquatableEither<T1, T2, T3, T4> value) => value.Second;
        public static implicit operator T3(EquatableEither<T1, T2, T3, T4> value) => value.Third;
        public static implicit operator T4(EquatableEither<T1, T2, T3, T4> value) => value.Fourth;
    }
}
