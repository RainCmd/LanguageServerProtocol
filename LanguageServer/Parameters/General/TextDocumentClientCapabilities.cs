﻿namespace LanguageServer.Parameters.General
{
    /// <summary>
    /// For <c>initialize</c>
    /// </summary>
    /// <seealso>Spec 3.10.0</seealso>
    public class TextDocumentClientCapabilities
    {
        /// <summary>
        /// 特定于文本文档同步的功能，例如 textDocument/willSave 、 textDocument/didSave 等
        /// </summary>
        public SynchronizationCapabilities? synchronization;

        /// <summary>
        /// Capabilities specific to the <c>textDocument/completion</c>
        /// </summary>
        public CompletionCapabilities? completion;

        /// <summary>
        /// Capabilities specific to the <c>textDocument/hover</c>
        /// </summary>
        /// <seealso>Spec 3.3.0</seealso>
        public HoverCapabilities? hover;

        /// <summary>
        /// Capabilities specific to the <c>textDocument/signatureHelp</c>
        /// </summary>
        /// <seealso>Spec 3.3.0</seealso>
        public SignatureHelpCapabilities? signatureHelp;

        /// <summary>
        /// Capabilities specific to the <c>textDocument/references</c>
        /// </summary>
        public RegistrationCapabilities? references;

        /// <summary>
        /// Capabilities specific to the <c>textDocument/documentHighlight</c>
        /// </summary>
        public RegistrationCapabilities? documentHighlight;

        /// <summary>
        /// Capabilities specific to the <c>textDocument/documentSymbol</c>
        /// </summary>
        /// <seealso>Spec 3.4.0</seealso>
        public SymbolCapabilities? documentSymbol;

        /// <summary>
        /// Capabilities specific to the <c>textDocument/formatting</c>
        /// </summary>
        public RegistrationCapabilities? formatting;

        /// <summary>
        /// Capabilities specific to the <c>textDocument/rangeFormatting</c>
        /// </summary>
        public RegistrationCapabilities? rangeFormatting;

        /// <summary>
        /// Capabilities specific to the <c>textDocument/onTypeFormatting</c>
        /// </summary>
        public RegistrationCapabilities? onTypeFormatting;

        /// <summary>
        /// Capabilities specific to the <c>textDocument/definition</c>
        /// </summary>
        public RegistrationCapabilities? definition;

        /// <summary>
        /// Capabilities specific to the <c>textDocument/typeDefinition</c>
        /// </summary>
        /// <seealso cref="ProviderOptions"/>
        /// <seealso>Spec 3.6.0</seealso>
        public RegistrationCapabilities? typeDefinition;

        /// <summary>
        /// Capabilities specific to the <c>textDocument/implementation</c>.
        /// </summary>
        /// <seealso cref="ProviderOptions"/>
        /// <seealso>Spec 3.6.0</seealso>
        public RegistrationCapabilities? implementation;

        /// <summary>
        /// Capabilities specific to the <c>textDocument/codeAction</c>.
        /// </summary>
        /// <seealso>Spec 3.8.0</seealso>
        public CodeActionCapabilities? codeAction;

        /// <summary>
        /// Capabilities specific to the <c>textDocument/codeLens</c>
        /// </summary>
        public RegistrationCapabilities? codeLens;

        /// <summary>
        /// Capabilities specific to the <c>textDocument/documentLink</c>
        /// </summary>
        public RegistrationCapabilities? documentLink;

        /// <summary>
        /// Capabilities specific to the <c>textDocument/documentColor</c> and the
        /// <c>textDocument/colorPresentation</c> request.
        /// </summary>
        /// <remarks>
        /// <c>dynamicRegistration</c> property shows whether colorProvider supports dynamic registration.
        /// If this is set to <c>true</c> the client supports the new
        /// <c>(ColorProviderOptions &amp; TextDocumentRegistrationOptions &amp; StaticRegistrationOptions)</c>
        /// return value for the corresponding server capability as well.
        /// </remarks>
        /// <seealso cref="ColorProviderOptions"/>
        /// <seealso>Spec 3.6.0</seealso>
        public RegistrationCapabilities? colorProvider;

        /// <summary>
        /// Capabilities specific to the <c>textDocument/rename</c>
        /// </summary>
        public RegistrationCapabilities? rename;

        /// <summary>
        /// Capabilities specific to <c>textDocument/publishDiagnostics</c>.
        /// </summary>
        /// <seealso>Spec 3.7.0</seealso>
        public PublishDiagnosticsCapabilities? publishDiagnostics;

        /// <summary>
        /// Capabilities specific to <c>textDocument/foldingRange</c> requests.
        /// </summary>
        /// <seealso>Spec 3.10.0</seealso>
        public FoldingRangeCapabilities? foldingRange;

        /// <summary>
        /// Capabilities specific to the `textDocument/inlineValue` request.
        /// </summary>
        /// <seealso>Spec 3.17.0</seealso>
        public RegistrationCapabilities? inlineValue;

        /// <summary>
        /// Capabilities specific to the `textDocument/inlayHint` request.
        /// </summary>
        /// <seealso>Spec 3.17.0</seealso>
        public InlayHintClientCapabilities? inlayHint;

        /// <summary>
        /// Capabilities specific to the various call hierarchy requests.
        /// </summary>
        /// <seealso>Spec 3.16.0</seealso>
        public CallHierarchyClientCapabilities? callHierarchy;

        /// <summary>
        /// Capabilities specific to the various type hierarchy requests.
        /// </summary>
        /// <seealso>Spec 3.17.0</seealso>
        public TypeHierarchyClientCapabilities? typeHierarchy;
    }
}
