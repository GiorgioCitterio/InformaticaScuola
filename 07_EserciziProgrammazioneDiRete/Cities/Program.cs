using SettingProxy;
using Cities.Model;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.Net.Http;

namespace Cities
{
    
    public class Program
    {
        static HttpClient client;
        
        public static List<CityModel> Cities { get; private set; } = new List<CityModel>();
        private static async Task AddCities()
        {
            var cities = new List<string>();
            var httpClient = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://wft-geo-db.p.rapidapi.com/v1/geo/cities?countryIds=EU&minPopulation=3000&sort=city"),
                Headers =
            {
                { "x-rapidapi-key", "9a3f081129mshfb0dee458d0da50p1f4130jsnc487f34aa7aa" },
                { "x-rapidapi-host", "wft-geo-db.p.rapidapi.com" },
            },
            };
            using (var response = await httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var responseContent = await response.Content.ReadAsStringAsync();
                dynamic jsonResponse = JsonConvert.DeserializeObject(responseContent);
                foreach (var item in jsonResponse.data)
                {
                    cities.Add(item.city);
                }
            }
            Console.WriteLine($"Number of cities: {cities.Count}");
            Console.WriteLine(string.Join(", ", cities));
        }
    
    
        static async Task Main(string[] args)
        {
            MyProxy.HttpClientProxySetup(out client);
            await AddCities();
        }
    }
}