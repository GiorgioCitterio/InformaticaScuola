using System.Diagnostics;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Web;
using SettingProxy;
using _15_EsempioBingMaps.Model;
using _15_EsempioBingMaps.Model.Percorso;

namespace _15_EsempioBingMaps
{
    public class BingMapsStore
    {
        [JsonPropertyName("api_key")]
        public string APIKeyValue { get; set; } = string.Empty;

    }

    public class Program
    {

        static readonly BingMapsStore bingMapsStore = GetDataFromStore();
        static readonly string bingMapsApiKey = bingMapsStore.APIKeyValue;
        static HttpClient client;

        static async Task ScaricaMappaStaticaByQuery(string address)
        {
            // recupero  il punto
            Point? punto = await FindLocationByQuery(address);
            if (punto != null)
            {
                Console.WriteLine($"Le coordinate del punto corrispondente all'indirizzo fornito sono (lat, lon): {punto.Coordinates[0]}, {punto.Coordinates[1]}");
                string fileName = "mappaByQuery.jpg";
                string pathToFile = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + Path.DirectorySeparatorChar + fileName;
                FormattableString unformat = $"{punto.Coordinates[0]},{punto.Coordinates[1]}";
                string formatPoint = FormattableString.Invariant(unformat);
                await ScaricaMappaStatica(formatPoint, pathToFile);
            }
        }
        static async Task ScaricaMappaStatica(string center, string pathToFile)
        {
            // Corregere il problema della cultura

            string mapCenter = HttpUtility.UrlEncode(center);
            int zoomLevel = 17;
            string mapSize = HttpUtility.UrlEncode("1024, 1024");
            string mapUrl = $"https://dev.virtualearth.net/REST/v1/Imagery/Map/Aerial/{mapCenter}/{zoomLevel}?mapSize={mapSize}&key={bingMapsApiKey}";
            await ScaricaMappaDaBingMaps(mapUrl, pathToFile);
        }
        static async Task ScaricaMappaDaBingMaps(string mapUrl, string pathToFile)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(mapUrl);
                response.EnsureSuccessStatusCode();
                await using Stream streamToReadFrom = await response.Content.ReadAsStreamAsync();
                //copio in modalità async il file 
                await WriteBinaryAsync(pathToFile, streamToReadFrom);
            }
            catch (HttpRequestException e)
            {

                Debug.WriteLine("\nException Caught!");
                Debug.WriteLine("Message :{0} ", e.Message);
            }

        }
        static async Task WriteBinaryAsync(string filePathDestination, Stream inputStream, int writeBufferSize = 4096)
        {
            using FileStream outputStream = new FileStream(filePathDestination,
                FileMode.Create, FileAccess.Write, FileShare.None,
                bufferSize: writeBufferSize, useAsync: true);
            await inputStream.CopyToAsync(outputStream);
        }
        static async Task EsempioFindLocationByAddress()
        {
            string postalCode = "23876";
            string locality = HttpUtility.UrlEncode("Monticello Brianza");
            string addressLine = HttpUtility.UrlEncode("Via dei Mille, 27");
            int includeNeighborhood = 1;
            string includeValue = "ciso2";
            int maxResults = 5;

            string addressUrl = $"https://dev.virtualearth.net/REST/v1/Locations/IT/{postalCode}/{locality}/{addressLine}?includeNeighborhood={includeNeighborhood}&include={includeValue}&maxResults={maxResults}&key={bingMapsApiKey}";
            try
            {
                HttpResponseMessage response = await client.GetAsync(addressUrl);
                if (response.IsSuccessStatusCode)
                {
                    Location? data = await response.Content.ReadFromJsonAsync<Location>();
                    Point? point = data.ResourceSets?[0].Resources?[0].Point;
                    if (data != null && point != null)
                    {
                        JsonSerializerOptions options =
                            new(JsonSerializerDefaults.Web)
                            { WriteIndented = true };
                        Console.WriteLine("Dati recuperati");
                        Console.WriteLine(JsonSerializer.Serialize(point, options));
                        Console.WriteLine("Lat= " + point.Coordinates?[0]);
                        Console.WriteLine("Lon= " + point.Coordinates?[1]);

                    }
                }
            }
            catch (Exception)
            {

                Console.WriteLine("Errore");
            }
        }
        static async Task<Point?> FindLocationByAddress(string countryCode, string postalCode, string locality, string addressLine)
        {
            locality = HttpUtility.UrlEncode(locality);
            addressLine = HttpUtility.UrlEncode(addressLine);
            int includeNeighborhood = 1;
            string includeValue = "ciso2";
            int maxResults = 1;
            string addressUrl = $"https://dev.virtualearth.net/REST/v1/Locations/{countryCode}/{postalCode}/{locality}/{addressLine}?includeNeighborhood={includeNeighborhood}&include={includeValue}&maxResults={maxResults}&key={bingMapsApiKey}";
            Point? point = null;
            try
            {
                HttpResponseMessage response = await client.GetAsync(addressUrl);
                Location? data = await response.Content.ReadFromJsonAsync<Location>();
                point = data?.ResourceSets?[0].Resources?[0].Point;
            }
            catch (Exception ex)
            {
                if (ex is HttpRequestException || ex is ArgumentException)
                {
                    Debug.WriteLine(ex.Message + "\nIl recupero dei dati dal server non è riuscito");
                }
            }
            return point;
        }
        static async Task<Point?> FindLocationByQuery(string queryString)
        {
            //https://docs.microsoft.com/en-us/bingmaps/rest-services/locations/find-a-location-by-query
            //esempio: https://dev.virtualearth.net/REST/v1/Locations/{locationQuery}?includeNeighborhood={includeNeighborhood}&maxResults={maxResults}&include={includeValue}&key={BingMapsAPIKey}
            //https://docs.microsoft.com/en-us/bingmaps/rest-services/locations/find-a-location-by-query#api-parameters
            int includeNeighborhood = 1;
            string includeValue = "queryParse,ciso2";
            int maxResults = 1;
            string locationQuery = HttpUtility.UrlEncode(queryString);
            string addressUrl = $"https://dev.virtualearth.net/REST/v1/Locations/{locationQuery}?includeNeighborhood={includeNeighborhood}&maxResults={maxResults}&include={includeValue}&key={bingMapsApiKey}";
            Point? point = null;
            try
            {
                HttpResponseMessage response = await client.GetAsync(addressUrl);
                Location? data = await response.Content.ReadFromJsonAsync<Location>();
                point = data?.ResourceSets?[0].Resources?[0].Point;
            }
            catch (Exception ex)
            {
                if (ex is HttpRequestException || ex is ArgumentException)
                {
                    Console.WriteLine(ex.Message + "\nIl recupero dei dati dal server non è riuscito");
                }

            }
            return point;
        }
        static async Task InfoPercorso(string start, string end)
        {
            start = HttpUtility.UrlEncode(start);
            end = HttpUtility.UrlEncode(end);
            string url = $"https://dev.virtualearth.net/REST/v1/Routes?wp.1={start}&wp.2={end}&optimize=time&tt=departure&dt=2022-02-22%2019:35:00&distanceUnit=km&c=it&ra=regionTravelSummary&key={bingMapsApiKey}";
            await Console.Out.WriteLineAsync(url);
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                BingPath? bingPath = await response.Content.ReadFromJsonAsync<BingPath>();
                int? durata = bingPath.ResourceSets[0].Resources[0].TravelDuration;
                await Console.Out.WriteLineAsync(durata);
            }
        }

        static async Task Main(string[] args)
        {
            MyProxy.HttpClientProxySetup(out client);
            //await EsempioFindLocationByAddress();
            //Point? p = await FindLocationByQuery("Via Luvoni 3 20831 Seregno MB Italia");
            //Console.WriteLine(p.Coordinates?[0] + " " + p.Coordinates?[1]);
            //await ScaricaMappaStaticaByQuery("Via dei Mille 27, 20843 Monticello Brianza LC, Italia");
            await InfoPercorso("Via Marconi 13 Cassago Brianza", "Via Como 2C Colle Brianza");
        }

        static BingMapsStore GetDataFromStore()
        {
            string keyStorePath = "..//..//..//..//..//..//..//BingMapStore//MyBingApiKey.json";
            string store = File.ReadAllText(keyStorePath);
            BingMapsStore? bingMapsStore = JsonSerializer.Deserialize<BingMapsStore>(store);
            return bingMapsStore ?? new BingMapsStore();
        }
    }
}