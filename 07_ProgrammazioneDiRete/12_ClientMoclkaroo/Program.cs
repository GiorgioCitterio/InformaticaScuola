using _12_ClientMoclkaroo.Model;
using SettingProxy;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace _12_ClientMockaroo
{
    public class Program
    {
        const string APIKeyName = "X-API-Key";
        readonly static string APIKeyValue = GetKeyFromStore();
        static string baseAddress = "https://my.api.mockaroo.com";
        static string acceptedMediaType = "application/json";
        static HttpClient? client;
        const string PATH = "Products.json";

        private static string GetKeyFromStore()
        {
            string keyStorePath = "../../../../../../MockarooKeys/MockKey.txt";
            string key = File.ReadAllText(keyStorePath);
            return key;
        }
        static async Task RunAsync()
        {
            client.BaseAddress = new Uri(baseAddress);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(acceptedMediaType));
            client.DefaultRequestHeaders.Add(APIKeyName, APIKeyValue);
            //Console.WriteLine("------------------ Get products ---------------");
            //var products = await GetProductsAsync(PATH);
            //ShowProducts(products);
            Console.WriteLine("------------------ Get product ---------------");
            await Console.Out.WriteLineAsync("Inserisci l'id del prodotto");
            string? id = Console.ReadLine();
            var product = await GetProductAsync($"product/{id}.json");
            if ( product != null ) 
            {
                ShowProduct(product);
            }
        }

        //restituisce un solo prodotto
        static async Task<Product> GetProductAsync(string path)
        {
            Product? product = null;
            HttpResponseMessage httpResponseMessage = await client.GetAsync(path);
            if(httpResponseMessage.IsSuccessStatusCode)
            {
                product = await httpResponseMessage.Content.ReadFromJsonAsync<Product>();
            }
            return product;
        }

        //restituisce una lista di prodotti
        static async Task<List<Product?>> GetProductsAsync(string path)
        {
            Stream stream = await client.GetStreamAsync(path);
            var products = await JsonSerializer.DeserializeAsync<List<Product?>>(stream);
            return products;
        }

        static void ShowProducts(List<Product> products)
        {
            products.ForEach(p => ShowProduct(p));
        }

        static void ShowProduct(Product product)
        {
            Console.WriteLine(product);
        }

        static async Task Main(string[] args)
        {
            MyProxy.HttpClientProxySetup(out client);
            //Console.WriteLine(GetKeyFromStore());
            await RunAsync();
        }
    }
}