using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Web;
using _14_EsempioPrevisioni.Model;
using SettingProxy;

namespace _14_EsempioPrevisioni
{
    public class OpenWeatherMapStore
    {
        [JsonPropertyName("api_key")]
        public string APIKeyValue { get; set; } = string.Empty;
    }
    public class Program
    {
        static readonly OpenWeatherMapStore openWeatherMapStore = GetDataFromStore();
        static readonly string openWeatherMapKey = openWeatherMapStore.APIKeyValue;
        static HttpClient? client;
        static async Task PrevisioniCorrenti()
        {
            string city = "Cassago Brianza";
            string cityName = HttpUtility.UrlEncode(city);
            string countryCode = "it";
            int limit = 5;
            string geocodingUrl = $"https://api.openweathermap.org/geo/1.0/direct?q={cityName},{countryCode}&limit={limit}&appid={openWeatherMapKey}";
            try
            {
                HttpResponseMessage response = await client.GetAsync(geocodingUrl);
                if (response.IsSuccessStatusCode)
                {
                    List<Location>? locationList = await response.Content.ReadFromJsonAsync<List<Location>>();
                    double lat = locationList[0].Lat;
                    double lon = locationList[0].Lon;
                    Console.WriteLine("Lat " + lat + " Lon " + lon);
                    // recupero le previsioni
                    string units = "metric";
                    string lang = "it";

                    string addressUrl = $"https://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&units={units}&lang={lang}&appid={openWeatherMapKey}";
                    response = await client.GetAsync(addressUrl);
                    Forecast? currentForecast = await response.Content.ReadFromJsonAsync<Forecast>();
                    JsonSerializerOptions options = new(JsonSerializerDefaults.Web) { WriteIndented = true };
                    Console.WriteLine("Dati ricevuti dall'endpoint remoto:\n" + JsonSerializer.Serialize(currentForecast, options));

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static async Task Main(string[] args)
        {
            MyProxy.HttpClientProxySetup(out client);
            await PrevisioniCorrenti();
        }

        static OpenWeatherMapStore GetDataFromStore()
        {
            string keyStorePath = "../../../../../../../WeatherMapStore//MyWeatherApiKey.json";
            string store = File.ReadAllText(keyStorePath);
            OpenWeatherMapStore? openWeatherMapStore = JsonSerializer.Deserialize<OpenWeatherMapStore>(store);
            return openWeatherMapStore ?? new OpenWeatherMapStore();
        }
    }
}