namespace github_stats.Interfaces
{
    public interface IGetFileResponse
    {
        public IEnumerable<IFile> Files { get; set; }
    }
}
