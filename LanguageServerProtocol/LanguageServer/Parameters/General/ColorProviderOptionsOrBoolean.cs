using LanguageServer.Json;

namespace LanguageServer.Parameters.General
{
    /// <summary>
    /// For <c>initialize</c><br/>
    /// <see cref="ColorProviderOptions"/> | <see cref="bool"/>
    /// </summary>
    /// <remarks>
    /// The original spec describes the union type of
    /// <c>boolean</c>, <c>ColorProviderOptions</c>, or the intersection type
    /// <c>(ColorProviderOptions &amp; TextDocumentRegistrationOptions &amp; StaticRegistrationOptions)</c>.
    /// This implementation defines <see cref="ColorProviderOptions"/> class instead of the intersection type.
    /// </remarks>
    /// <seealso>Spec 3.8.0</seealso>
    public class ColorProviderOptionsOrBoolean : Either<ColorProviderOptions, bool>
    {
        /// <summary>
        /// Initializes a new instance of <c>ColorProviderOptionsOrBoolean</c> with the specified value.
        /// </summary>
        /// <param name="value"></param>
        /// <seealso>Spec 3.8.0</seealso>
        public ColorProviderOptionsOrBoolean(ColorProviderOptions value) : base(value) { }

        /// <summary>
        /// Initializes a new instance of <c>ColorProviderOptionsOrBoolean</c> with the specified value.
        /// </summary>
        /// <param name="value"></param>
        /// <seealso>Spec 3.8.0</seealso>
        public ColorProviderOptionsOrBoolean(bool value) : base(value) { }
        public static implicit operator ColorProviderOptionsOrBoolean(ColorProviderOptions value) => new(value);
        public static implicit operator ColorProviderOptionsOrBoolean(bool value) => new(value);
    }
}
