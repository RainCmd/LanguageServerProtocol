using LanguageServer.Json;

namespace LanguageServer.Parameters.TextDocument
{
    /// <summary>
    /// The hover's content
    /// </summary>
    /// <remarks>
    /// <see cref="string"/> | <see cref="string"/>[] | <see cref="MarkupContent"/> | <see cref="MarkupContent"/>[]
    /// </remarks>
    /// <seealso>Spec 3.3.0</seealso>
    public class HoverContents : Either<string, string[], MarkupContent, MarkupContent[]>
    {
        /// <summary>
        /// Initializes a new instance of <c>HoverContents</c> with the specified value.
        /// </summary>
        public HoverContents(string value) : base(value) { }

        /// <summary>
        /// Initializes a new instance of <c>HoverContents</c> with the specified value.
        /// </summary>
        public HoverContents(string[] value) : base(value) { }

        /// <summary>
        /// Initializes a new instance of <c>HoverContents</c> with the specified value.
        /// </summary>
        /// <seealso>Spec 3.3.0</seealso>
        public HoverContents(MarkupContent value) : base(value) { }

        /// <summary>
        /// Initializes a new instance of <c>HoverContents</c> with the specified value.
        /// </summary>
        /// <seealso>Spec 3.3.0</seealso>
        public HoverContents(MarkupContent[] value) : base(value) { }

        public static implicit operator HoverContents(string value) => new(value);
        public static implicit operator HoverContents(string[] value) => new(value);
        public static implicit operator HoverContents(MarkupContent value) => new(value);
        public static implicit operator HoverContents(MarkupContent[] value) => new(value);
    }
}
