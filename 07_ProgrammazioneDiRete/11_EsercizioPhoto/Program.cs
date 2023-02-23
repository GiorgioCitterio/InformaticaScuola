using _11_EsercizioPhoto.Model;
using SettingProxy;
using System.Net.Http.Json;
using System.Text.Json;
namespace _11_EsercizioPhoto
{
    public class Program
    {
        static HttpClient client;
        static async Task DeserializzaJsonAsync()
        {
            MyProxy.HttpClientProxySetup(out client);
            client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/photos");
            List<Photo>? photos = await client.GetFromJsonAsync<List<Photo>>("photos");
            var ultimePhoto = photos?.Skip(Math.Max(0, photos.Count() - 10));
            foreach (var item in ultimePhoto)
            {
                Console.WriteLine(item);
            } 
        }
        static async Task Main(string[] args)
        {
           await DeserializzaJsonAsync();
        }
    }
}