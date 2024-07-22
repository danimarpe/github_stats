using github_stats.Interfaces;

namespace github_stats.Services
{
    public class FileService : IFileService
    {
        public IList<IFile> Sort(IEnumerable<IFile> files)
        {
            return files.OrderByDescending(f => f.GetSize()).ToList();
        }

        public void Print(IEnumerable<IFile> files)
        {
            foreach (var file in files)
            {
                Console.WriteLine(file.ToString());
            }
        }
    }
}
