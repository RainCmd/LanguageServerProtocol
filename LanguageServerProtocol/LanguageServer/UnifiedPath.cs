using System.Text.RegularExpressions;

namespace LanguageServer
{
    /// <summary>
    /// 将路径统一为小写盘符开头，然后冒号加路径，路径之间使用单个“/”分割
    /// </summary>
    public readonly partial struct UnifiedPath
    {
        public readonly string path;
        public UnifiedPath(string path)
        {
            var index = path.IndexOf(':');
            if (index > 0) path = string.Concat(path[..index].ToLower(), path.AsSpan(index));
            this.path = regex.Replace(path.Replace("\\", "/"), "/");
        }
        public UnifiedPath(Uri uri)
        {
            path = regex.Replace(uri.LocalPath.TrimStart('/'), "/");
        }
        public static implicit operator string(UnifiedPath path) { return path.path; }
        private static readonly Regex regex = SimplifyRegex();
        [GeneratedRegex("/+")]
        private static partial Regex SimplifyRegex();
    }
}
