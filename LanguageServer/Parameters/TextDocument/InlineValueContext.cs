namespace LanguageServer.Parameters.TextDocument
{
    public class InlineValueContext(long frameId, Range stoppedLocation)
    {
        /// <summary>
        /// The stack frame (as a DAP Id) where the execution has stopped.
        /// </summary>
        long frameId = frameId;
        /// <summary>
        /// The document range where execution has stopped.
        /// Typically the end position of the range denotes the line where the inline values are shown.
        /// </summary>
        Range stoppedLocation = stoppedLocation;
    }
}
