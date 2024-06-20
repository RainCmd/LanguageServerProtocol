using LanguageServer.Json;

namespace LanguageServer.Parameters.General
{
    /// <summary>
    /// For <c>initialize</c><br/>
    /// <see cref="ProviderOptions"/> | <see cref="bool"/>
    /// </summary>
    /// <remarks>
    /// The original spec describes the union type of <c>boolean</c> or the intersection type
    /// <c>(TextDocumentRegistrationOptions &amp; StaticRegistrationOptions)</c>.
    /// This implementation defines <see cref="ProviderOptions"/> class instead of the intersection type.
    /// </remarks>
    /// <seealso>Spec 3.6.0</seealso>
    public class ProviderOptionsOrBoolean : Either<ProviderOptions, bool>
    {
        /// <summary>
        /// Initializes a new instance of <c>ProviderOptionsOrBoolean</c> with the specified value.
        /// </summary>
        /// <param name="value"></param>
        /// <seealso>Spec 3.6.0</seealso>
        public ProviderOptionsOrBoolean(ProviderOptions value) : base(value) { }

        /// <summary>
        /// Initializes a new instance of <c>ProviderOptionsOrBoolean</c> with the specified value.
        /// </summary>
        /// <param name="value"></param>
        /// <seealso>Spec 3.6.0</seealso>
        public ProviderOptionsOrBoolean(bool value) : base(value) { }

        public static implicit operator ProviderOptionsOrBoolean(ProviderOptions value) => new(value);
        public static implicit operator ProviderOptionsOrBoolean(bool value) => new(value);
    }
}
