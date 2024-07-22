using github_stats.Interfaces;
using github_stats.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public class Program
{
    public static ServiceProvider InjectDependencies()
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                        .Build();

        return new ServiceCollection()
            .Configure<GitHubSettings>(configuration.GetSection("GitHubSettings"))
            .AddOptions()
            .AddSingleton<IRepoService, GitHubService>()
            .AddSingleton<IFileService, FileService>()
            .BuildServiceProvider();
    }
    public static void Main(string[] args)
    {
        ServiceProvider serviceProvider = InjectDependencies();        
        IRepoService repoService = serviceProvider.GetRequiredService<IRepoService>();
        IFileService fileService = serviceProvider.GetRequiredService<IFileService>();

        IList<IFile> filesSorted = fileService.Sort(repoService.GetFiles().Files);
        fileService.Print(filesSorted);

        Console.ReadKey();
    }
}