namespace github_stats.Interfaces
{
    public interface IFile
    {
        long GetLetters();

        string GetName();

        long GetSize();

        string ToString();
    }
}
