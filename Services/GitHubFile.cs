using github_stats.Interfaces;

namespace github_stats.Services
{
    public class GitHubFile : IFile
    {
        private long _size { get; set; }
        private string _name { get; set; }

        private byte[] _content { get; set; }

        private LetterStats _stats { get; set; }

        public GitHubFile(long size, string name, byte[] content)
        {
            _size = size;
            _name = name;
            _content = content;
            _stats = new LetterStats(GetLetters());
        }

        public long GetSize()
        {
            return _size;
        }

        public string GetName()
        {
            return _name;
        }

        public byte[] GetLetters()
        {
            return _content.Where(c => Char.IsLetter((char)c)).ToArray();
        }

        public LetterStats GetLetterStats()
        {
            return _stats;
        }

        public override string ToString()
        {
            return GetName() + " - Total Size: " + GetSize() + " \n   LetterStats: " + GetLetterStats().ToString();
        }
    }
}
