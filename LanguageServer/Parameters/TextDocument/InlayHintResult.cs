using LanguageServer.Parameters.General;

namespace LanguageServer.Parameters.TextDocument
{
    /// <summary>
    /// Inlay hint kinds.
    /// </summary>
    public static class InlayHintKind
    {
        /// <summary>
        /// An inlay hint that for a type annotation.
        /// </summary>
        public const long Type = 1;
        /// <summary>
        /// An inlay hint that is for a parameter.
        /// </summary>
        public const long Parameter = 2;
    }
    /// <summary>
    /// Inlay hint information.
    /// @since 3.17.0
    /// </summary>
    public class InlayHintResult(Position position, InlayHintLabel label)
    {
        /// <summary>
        /// The position of this hint.
        /// 
        /// If multiple hints have the same position, they will be shown in the order they appear in the response.
        /// </summary>
        public Position position = position;

        /// <summary>
        /// The label of this hint. A human readable string or an array of InlayHintLabelPart label parts.
        /// *Note* that neither the string nor the label part can be empty.
        /// </summary>
        public InlayHintLabel label = label;
        /// <summary>
        /// The kind of this hint. Can be omitted in which case the client should fall back to a reasonable default.
        /// </summary>
        /// <remarks>
        /// <see cref="InlayHintKind.Type"/> | <see cref="InlayHintKind.Parameter"/>
        /// </remarks>
        public long? kind;
        /// <summary>
        /// Optional text edits that are performed when accepting this inlay hint.
        /// 
        /// *Note* that edits are expected to change the document so that the inlay
        /// hint (or its nearest variant) is now part of the document and the inlay
        /// hint itself is now obsolete.
        /// 
        /// Depending on the client capability `inlayHint.resolveSupport` clients
        /// might resolve this property late using the resolve request.
        /// </summary>
        public TextEdit[]? textEdits;
        /// <summary>
        /// The tooltip text when you hover over this item.
        /// 
        /// Depending on the client capability `inlayHint.resolveSupport` clients
        /// might resolve this property late using the resolve request.
        /// </summary>
        public Documentation? tooltip;
        /// <summary>
        /// Render padding before the hint.
        /// 
        /// Note: Padding should use the editor's background color, not the
        /// background color of the hint itself. That means padding can be used
        /// to visually align/separate an inlay hint.
        /// </summary>
        public bool? paddingLeft;
        /// <summary>
        /// Render padding after the hint.
        /// 
        /// Note: Padding should use the editor's background color, not the
        /// background color of the hint itself. That means padding can be used
        /// to visually align/separate an inlay hint.
        /// </summary>
        public bool? paddingRight;
        /// <summary>
        /// A data entry field that is preserved on an inlay hint between
        /// a `textDocument/inlayHint` and a `inlayHint/resolve` request.
        /// </summary>
        public dynamic? data;
    }
}
