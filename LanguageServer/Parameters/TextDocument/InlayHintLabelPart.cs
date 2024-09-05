﻿namespace LanguageServer.Parameters.TextDocument
{
    /// <summary>
    /// An inlay hint label part allows for interactive and composite labels of inlay hints.
    /// </summary>
    /// <seealso cref="@since 3.17.0"/>
    public class InlayHintLabelPart(string value)
    {
        /// <summary>
        /// The value of this label part.
        /// </summary>
        public string value = value;
        /// <summary>
        /// The tooltip text when you hover over this label part. Depending on
        /// the client capability `inlayHint.resolveSupport` clients might resolve
        /// this property late using the resolve request.
        /// </summary>
        public Documentation? tooltip;
        /// <summary>
        /// An optional source code location that represents this label part.
        /// 
        /// The editor will use this location for the hover and for code navigation
        /// features: This part will become a clickable link that resolves to the
        /// definition of the symbol at the given location (not necessarily the
        /// location itself), it shows the hover that shows at the given location,
        /// and it shows a context menu with further code navigation commands.
        /// 
        /// Depending on the client capability `inlayHint.resolveSupport` clients
        /// might resolve this property late using the resolve request.
        /// </summary>
        public Location? location;
        /// <summary>
        /// An optional command for this label part.
        /// 
        /// Depending on the client capability `inlayHint.resolveSupport` clients
        /// might resolve this property late using the resolve request.
        /// </summary>
        public Command? command;
    }
}
