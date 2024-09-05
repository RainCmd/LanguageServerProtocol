using LanguageServer.Json;
using LanguageServer.Parameters.TextDocument;

namespace LanguageServer.Parameters.General
{
    /// <summary>
    /// The label of this hint. A human readable string or an array of InlayHintLabelPart label parts.
    /// 
    /// *Note* that neither the string nor the label part can be empty.
    /// </summary>
    public class InlayHintLabel : Either<string, InlayHintLabelPart[]>
    {
        public InlayHintLabel(string value) : base(value) { }
        public InlayHintLabel(InlayHintLabelPart[] value) : base(value) { }
        public static implicit operator InlayHintLabel(string value) => new(value);
        public static implicit operator InlayHintLabel(InlayHintLabelPart[] value) => new(value);
    }
}
