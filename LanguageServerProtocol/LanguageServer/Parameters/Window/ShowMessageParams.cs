namespace LanguageServer.Parameters.Window
{
    public class ShowMessageParams(MessageType type, string message)
    {
        public MessageType type = type;
        public string message = message;
    }
}
