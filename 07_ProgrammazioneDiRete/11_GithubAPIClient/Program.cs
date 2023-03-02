using SettingProxy;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace _11_GithubAPIClient
{
    public class Repository
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = null!;

        [JsonPropertyName("description")]
        public string Description { get; set; } = null!;

        [JsonPropertyName("html_url")]
        public Uri GitHubHomeUrl { get; set; } = null!;

        [JsonPropertyName("homepage")]
        public Uri Homepage { get; set; } = null!;

        [JsonPropertyName("watchers")]
        public int Watchers { get; set; }

        [JsonPropertyName("pushed_at")]
        public DateTime LastPushUtc { get; set; }

        public DateTime LastPush => LastPushUtc.ToLocalTime();

    }

    public class Program
    {
        static HttpClient client;
        static async Task<List<Repository>> ProcessRepositoriesAsync()
        {
            MyProxy.HttpClientProxySetup(out client);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
            
            await using Stream stream =
                await client.GetStreamAsync("https://api.github.com/orgs/dotnet/repos");
            var repositories =
                await JsonSerializer.DeserializeAsync<List<Repository>>(stream);
            return repositories ?? new();
        }

        static async Task Main(string[] args)
        {
            var repositories = await ProcessRepositoriesAsync();
            foreach (var repo in repositories)
            {
                Console.WriteLine(repo.Name);
                Console.WriteLine(repo.Description);
                Console.WriteLine(repo.GitHubHomeUrl);
                Console.WriteLine(repo.Homepage);
                Console.WriteLine(repo.Watchers);
                Console.WriteLine(repo.LastPushUtc);
            }
        }
    }
}