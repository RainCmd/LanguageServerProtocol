namespace LanguageServer.Parameters.General
{
    public class TypeHierarchyClientCapabilities
    {
        /// <summary>
        /// Whether implementation supports dynamic registration. If this is set to
        /// `true` the client supports the new `(TextDocumentRegistrationOptions &
        /// StaticRegistrationOptions)` return value for the corresponding server
        /// capability as well.
        /// </summary>
        public bool dynamicRegistration;
    }
}
