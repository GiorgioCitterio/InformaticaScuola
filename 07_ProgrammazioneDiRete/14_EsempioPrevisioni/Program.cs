using System.Diagnostics;
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

        static async Task PrevisioniOpen()
        {
            string city = "Cassago Brianza";
            string countryCode = "it";
            (double lat, double lon)? geo = await GeocodeByOpenWeatherMap(city, countryCode);
            string url = $"https://api.open-meteo.com/v1/forecast?latitude={geo?.lat}&longitude={geo?.lon}&hourly=temperature_2m,temperature_1000hPa,dewpoint_1000hPa,relativehumidity_1000hPa,cloudcover_1000hPa,windspeed_1000hPa,winddirection_1000hPa,geopotential_height_1000hPa&models=ecmwf_ifs04&daily=temperature_2m_max,temperature_2m_min,sunrise,sunset,windspeed_10m_max,windgusts_10m_max&timezone=auto";
            var response = await client.GetAsync($"{url}");
            if (response.IsSuccessStatusCode)
            {
                OpenMeteoForecast? forecast = await response.Content.ReadFromJsonAsync<OpenMeteoForecast>();
                if (forecast != null)
                {
                    Console.WriteLine($"Latitutide: {forecast.Latitude}; Longitudine: {forecast.Longitude}; Elevazione: {forecast.Elevation} m; TimeZone: {forecast.Timezone}");
                    if(forecast.Daily != null)
                    {
                        Console.WriteLine("temp2min: " + forecast.Daily.Temperature2mMax + " temp2max: " + forecast.Daily.Temperature2mMin);
                    }
                }
            }

        }

        static async Task<(double lat, double lon)?> GeocodeByOpenWeatherMap(string? city, string? countryCode, int limit = 1)
        {
            string? cityUrlEncoded = HttpUtility.UrlEncode(city);
            string geocodingUrl = $"https://api.openweathermap.org/geo/1.0/direct?q={cityUrlEncoded},{countryCode}&limit={limit}&appid={openWeatherMapKey}";
            try
            {
                HttpResponseMessage responseGeocoding = await client.GetAsync($"{geocodingUrl}");
                if (responseGeocoding.IsSuccessStatusCode)
                {
                    List<Location>? geocodingResult = await responseGeocoding.Content.ReadFromJsonAsync<List<Location>>();
                    if (geocodingResult != null && geocodingResult.Count > 0)
                    {
                        return (geocodingResult[0].Lat, geocodingResult[0].Lon);
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                if (ex is HttpRequestException || ex is ArgumentException)
                {
                    Debug.WriteLine(ex.Message + "\nIl recupero dei dati dal server non è riuscito");
                }
            }
            return null;
        }

        static async Task Main(string[] args)
        {
            MyProxy.HttpClientProxySetup(out client);
            //await PrevisioniCorrenti();
            await PrevisioniOpen();
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