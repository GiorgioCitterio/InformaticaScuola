using _13_ClientMockApiPostman.Model;
using SettingProxy;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace _13_ClientMockApiPostman
{
    public class Program
    {
        static HttpClient? client;
        const string APIKeyName = "X-API-Key";
        static PostmanStore? postmanStore = GetDataFromStore();
        static readonly string? APIKeyValue = postmanStore.APIKeyValue;
        static string? baseAddress = postmanStore.BaseAddress;
        static string? acceptedMediaType = "application/json";
        const string PATH = "Products";

        static async Task RunAsAsync()
        {
            client.BaseAddress = new Uri(baseAddress);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(acceptedMediaType));
            client.DefaultRequestHeaders.Add(APIKeyName, APIKeyValue);
            //testo API
            #region GET PRODUCTS
            //var listaProdotti = await GetProductsAsync(PATH);
            //ShowProducts(listaProdotti);
            #endregion

            #region GET COMPANIES
            //Console.WriteLine("Elenco di tutte le compagnie");
            //var companies = await GetCompaniesAsync("Companies");
            //if (companies != null)
            //{
            //    JsonSerializerOptions options = new() { WriteIndented = true };
            //    companies.ForEach(c => Console.WriteLine(JsonSerializer.Serialize(c, options) + "\n"));
            //}
            #endregion

            #region POST PRODUCTS
            Product? p = new Product()
            {
                Name = "Mele",
                Price = 20,
                CompanyID = 35
            };
            Uri? url = await PostProductAsync(p);
            if (url != null)
            {
                Console.WriteLine("Prodotto caricato sul server");
                //recupero il prodotto caricato che sarà diverso da
                //quello inserito perchè fake mackaroo
                p = await GetProductAsync(url.PathAndQuery);
                if (p != null)
                    ShowProduct(p);
            }
            #endregion
        }

        #region API Product
        static async Task<List<Product?>> GetProductsAsync(string path)
        {
            Stream stream = await client.GetStreamAsync(path);
            var products = await JsonSerializer.DeserializeAsync<List<Product?>>(stream);
            return products;
        }

        static async Task<Product> GetProductAsync(string path)
        {
            Product? product = null;
            HttpResponseMessage httpResponseMessage = await client.GetAsync(path);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                product = await httpResponseMessage.Content.ReadFromJsonAsync<Product>();
            }
            return product;
        }

        static async Task<Uri?> PostProductAsync(Product p)
        {
            var response = await client.PostAsJsonAsync(PATH, p);
            if (response.IsSuccessStatusCode)
            {
                Product? prodCreato = await response.Content.ReadFromJsonAsync<Product>();
                // devo restituire il json del prodotto creato
                Console.WriteLine("Prodotto creato " +
                    "" + JsonSerializer.Serialize(prodCreato));
            }
            // secondo modo 
            string responseContentAsString = await response.Content.ReadAsStringAsync();
            // creo il prodotto
            Product? prodC = JsonSerializer.Deserialize<Product?>(responseContentAsString);
            if (prodC != null)
            {
                Console.WriteLine("Prodotto creato " +
                    " " + responseContentAsString);
            }

            // se restituito uri response
            Uri? uri = response.Headers.Location;
            if (uri != null)
            {
                Console.WriteLine("Header location " + uri);
                return uri;
            }
            else
                return null;
        }

        static void ShowProducts(List<Product> products)
        {
            products.ForEach(p => ShowProduct(p));
        }

        static void ShowProduct(Product product)
        {
            Console.WriteLine(product);
        }
        #endregion

        #region API Companies
        static async Task<List<Company?>> GetCompaniesAsync(string path)
        {
            await using Stream stream = await client.GetStreamAsync(path);
            var companies = await JsonSerializer.DeserializeAsync<List<Company>>(stream);
            return companies;
        }
        #endregion

        static async Task Main(string[] args)
        {
            MyProxy.HttpClientProxySetup(out client);
            await RunAsAsync();
        }

        private static PostmanStore GetDataFromStore()
        {
            string keyStorePath = "../../../../../../PostmanKeys/PostmanApiKey.json";
            string store = File.ReadAllText(keyStorePath);
            PostmanStore? postmanStore = JsonSerializer.Deserialize<PostmanStore>(store);
            return postmanStore ?? new PostmanStore();
        }
    }
}