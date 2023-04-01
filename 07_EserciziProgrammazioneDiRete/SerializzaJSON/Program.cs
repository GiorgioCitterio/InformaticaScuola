using SerializzaJSON.Model;
using SettingProxy;
using System.Text.Json;

namespace SerializzaJSON
{
    public class Program
    {
        static HttpClient client;
        static List<CityModel>? lista = new List<CityModel>();
        static async Task GetPostsFromFileAsync()
        {
            string path = "..//..//..//cities.json";
            string json = await File.ReadAllTextAsync(path);
            lista = JsonSerializer.Deserialize<List<CityModel>>(json);
            Console.WriteLine(lista.Count);
        }
        static async Task SerializePosts()
        {
            string path = "..//..//..//newCities.json";
            Stream stream = File.OpenWrite(path);
            var options = new JsonSerializerOptions() { WriteIndented = true };
            await JsonSerializer.SerializeAsync(stream, lista, options);
            stream.Close();
            await Console.Out.WriteLineAsync(File.ReadAllText(path));
        }
        static async Task Main(string[] args)
        {
            MyProxy.HttpClientProxySetup(out client);
            await GetPostsFromFileAsync();
            await SerializePosts();
        }
    }
}