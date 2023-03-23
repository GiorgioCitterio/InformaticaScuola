using DeserializzazioneJson.Model;
using System.Net.Http.Json;
using System.Security.Cryptography;
using System.Text.Json;

namespace DeserializzazioneJson
{
    internal class Program
    {
        static HttpClient client = new HttpClient();
        static List<Post>? posts;

        #region Deserializzazione da internet 
        static async Task GetPostsAsync()
        {
            HttpResponseMessage response = await client.GetAsync("/albums");
            if (response.IsSuccessStatusCode)
            {
                posts = await response.Content.ReadFromJsonAsync<List<Post>>();
            }
            ShowPosts(posts);
        }
        static void ShowPosts(List<Post> posts)
        {
            posts.ForEach(post => ShowPost(post));
        }
        static void ShowPost(Post post)
        {
            Console.WriteLine(post);
        }
        #endregion

        #region Serializzazione Posts
        static async Task SerializePosts()
        {
            string path = "..//..//..//Posts.json";
            Stream stream = File.OpenWrite(path);
            var options = new JsonSerializerOptions() { WriteIndented = true };
            await JsonSerializer.SerializeAsync(stream, posts, options);
            stream.Close();
            await Console.Out.WriteLineAsync(File.ReadAllText(path));
        }
        #endregion

        #region Deserializzazione da file
        static async Task GetPostsFromFileAsync()
        {
            string path = "..//..//..//Posts.json";
            string json = File.ReadAllText(path);
            posts = JsonSerializer.Deserialize<List<Post>>(json);
            ShowPosts(posts);
        }
        #endregion
        static async Task Main(string[] args)
        {
            client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com");
            await Console.Out.WriteLineAsync("deserializzazione da internet");
            await GetPostsAsync();
            await Console.Out.WriteLineAsync("serializzazione da internet su file");
            await SerializePosts();
            await Console.Out.WriteLineAsync("deserializzazione da file");
            await GetPostsFromFileAsync();
        }
    }
}