namespace LanguageServer.Parameters.Workspace
{
    public class FileEvent(DocumentUri uri, FileChangeType type)
    {
        public DocumentUri uri = uri;
        public FileChangeType type = type;
    }
}
