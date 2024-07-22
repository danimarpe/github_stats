using github_stats.Interfaces;

namespace github_stats.Services
{
    public class GitHubFile : IFile
    {
        private long _size { get; set; }
        private string _name { get; set; }

        private byte[] _content { get; set; }

        public GitHubFile(long size, string name, byte[] content)
        {
            _size = size;
            _name = name;
            _content = content;
        }

        public long GetSize()
        {
            return _size;
        }

        public string GetName()
        {
            return _name;
        }

        public long GetLetters()
        {
            return _content.Where(c => Char.IsLetter((char)c)).Count();
        }

        public override string ToString()
        {
            return GetName() + " - Real Size: " + GetSize() + " - Letters: " + GetLetters();
        }
    }
}
