namespace LanguageServer.Parameters
{
    public class DocumentUri(string uri) : IEquatable<DocumentUri>, IEquatable<string>
    {
        public readonly string uri = uri;
        public DocumentUri(Uri uri) : this(uri.ToString()) { }
        public override string ToString() => uri;
        public override int GetHashCode() => uri.GetHashCode();
        public override bool Equals(object? obj)
        {
            return obj is DocumentUri uri && this == uri;
        }

        bool IEquatable<string>.Equals(string? other)
        {
            return uri == other;
        }
        bool IEquatable<DocumentUri>.Equals(DocumentUri? other)
        {
            return other?.uri == uri;
        }

        public static bool operator ==(DocumentUri? left, DocumentUri? right)
        {
            if (ReferenceEquals(left, right)) return true;
            else if (left is not null) return ((IEquatable<DocumentUri>)left).Equals(right);
            else if (right is not null) return ((IEquatable<DocumentUri>)right).Equals(left);
            return true;
        }
        public static bool operator !=(DocumentUri? left, DocumentUri? right) => !(left == right);
        public static implicit operator DocumentUri(string uri) => new(uri);
        public static implicit operator DocumentUri(Uri uri) => new(uri);
        public static implicit operator string(DocumentUri uri) => uri.uri;

    }
}
