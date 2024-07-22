namespace github_stats.Interfaces
{
    public interface IFile
    {
        byte[] GetLetters();

        string GetName();

        long GetSize();

        string ToString();
    }
}
