using github_stats.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using RestSharp;
using System.IO.Compression;


namespace github_stats.Services
{
    public class GitHubService : IRepoService
    {
        GitHubSettings _configuration;

        public GitHubService (IOptions<GitHubSettings> configuration)
        {
            _configuration = configuration.Value;
        }

        public IGetFileResponse GetFiles()
        {
            byte[] zipFile = DownloadFiles(_configuration.ApiURL);
            List<GitHubFile> codeFiles = ExtractTSAndJSFiles(zipFile);

            return new GitHubGetFileResponse(codeFiles);
        }

        private byte[] DownloadFiles(string apiUrl)
        {
            var client = new RestClient();
            byte[] zipBytes = client.DownloadData(new RestRequest(apiUrl + _configuration.RepoUrl)) ?? new byte[0];

            return zipBytes;
        }

        private byte[] ExtractFile(ZipArchiveEntry fileEntry)
        {
            using (Stream fileStream = fileEntry.Open()) {
                using (MemoryStream ms = new MemoryStream())
                {
                    fileStream.CopyTo(ms);
                    return ms.ToArray();
                }
            }
        }

        private List<GitHubFile> ExtractTSAndJSFiles(byte[] zipBytes)
        {
            List<GitHubFile> files = new List<GitHubFile>();
            using (Stream tempStream = new MemoryStream(zipBytes))
            {
                ZipArchive zipArchive = new ZipArchive(tempStream);

                files.AddRange(zipArchive.Entries
                    .Where(entry => entry.FullName.EndsWith(".js") || entry.FullName.EndsWith(".ts"))
                    .Select(f => new GitHubFile(f.Length, f.FullName, ExtractFile(f))).ToList());
            }

            return files;
        }
    }
}
