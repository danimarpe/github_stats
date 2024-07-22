using github_stats.Interfaces;

namespace github_stats.Services
{ 
    public class GitHubGetFileResponse : IGetFileResponse
    {
        public GitHubGetFileResponse(IEnumerable<IFile> files)
        {
            Files = files;
        }

        public IEnumerable<IFile> Files { get; set; }
    }
}
