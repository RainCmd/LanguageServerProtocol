using LanguageServer.Json;

namespace LanguageServer.Parameters.General
{
    /// <summary>
    /// For <c>initialize</c><br/>
    /// <see cref="FoldingRangeProviderOptions"/> | <see cref="bool"/>
    /// </summary>
    /// <remarks>
    /// The original spec describes the union type of
    /// <c>boolean</c>, <c>FoldingRangeProviderOptions</c>, or the intersection type
    /// <c>(FoldingRangeProviderOptions &amp; TextDocumentRegistrationOptions &amp; StaticRegistrationOptions)</c>.
    /// This implementation defines <see cref="FoldingRangeProviderOptions"/> class instead of the intersection type.
    /// </remarks>
    /// <seealso>Spec 3.10.0</seealso>
    public class FoldingRangeProviderOptionsOrBoolean : Either<FoldingRangeProviderOptions, bool>
    {
        /// <summary>
        /// Initializes a new instance of <c>FoldingRangeProviderOptionsOrBoolean</c> with the specified value.
        /// </summary>
        /// <param name="value"></param>
        public FoldingRangeProviderOptionsOrBoolean(FoldingRangeProviderOptions value) : base(value) { }

        /// <summary>
        /// Initializes a new instance of <c>FoldingRangeProviderOptionsOrBoolean</c> with the specified value.
        /// </summary>
        /// <param name="value"></param>
        public FoldingRangeProviderOptionsOrBoolean(bool value) : base(value) { }
        public static implicit operator FoldingRangeProviderOptionsOrBoolean(FoldingRangeProviderOptions value) => new(value);
        public static implicit operator FoldingRangeProviderOptionsOrBoolean(bool value) => new(value);
    }
}
