using _11_EsercizioPhoto.Model;
using SettingProxy;
using System.Net.Http.Json;

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
            List<Photo>? firstPhotos = new List<Photo>(10);
            for (int i = 0; i < firstPhotos.Count; i++)
            {
                firstPhotos[i] = photos[i];
            }
            List<Photo>? cachedPhotos = new List<Photo>();
            foreach (Photo photo in photos)
            {
                string fileName = Path.GetFileName(photo.url);
                string filePath = Path.Combine("cachedPhotos", fileName);
                photo.url = filePath;
                fileName = Path.GetFileName(photo.thumbnailUrl);
                filePath = Path.Combine("cachedThumbnails", fileName);
                photo.thumbnailUrl = filePath;
                cachedPhotos.Add(photo);
            }
            cachedPhotos.ForEach(photo => Console.WriteLine(photo));
        }
        static async Task Main(string[] args)
        {
           await DeserializzaJsonAsync();
        }
    }
}