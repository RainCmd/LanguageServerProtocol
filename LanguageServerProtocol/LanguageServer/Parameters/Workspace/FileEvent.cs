namespace LanguageServer.Parameters.Workspace
{
    public class FileEvent(FileEvent uri, FileChangeType type)
    {
        public FileEvent uri = uri;
        public FileChangeType type = type;
    }
}
