using _12_ClientMoclkaroo.Model;
using SettingProxy;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
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
            //IMPOSTAZIONI BASE CLIENT
            client.BaseAddress = new Uri(baseAddress);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(acceptedMediaType));
            client.DefaultRequestHeaders.Add(APIKeyName, APIKeyValue);

            #region TEST GET
            //GET PRODUCTS
            //Console.WriteLine("------------------ Get products ---------------");
            //var products = await GetProductsAsync(PATH);
            //ShowProducts(products);

            //GET PRODUCT
            //Console.WriteLine("------------------ Get product ---------------");
            //Console.Write("Inserire l'id del prodotto: ");
            //string? id = Console.ReadLine();
            //var product = await GetProductAsync($"Products/{id}.json");
            //if ( product != null ) 
            //{
            //    ShowProduct(product);
            //}
            #endregion

            #region TEST POST
            /*
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
                // altra modalità
                url = await PostProductAsync2(p);
                Console.WriteLine("Seconda modalità di Post");
                if (url != null)
                {
                    Console.WriteLine("Prodotto caricato sul server");
                    //recupero il prodotto caricato che sarà diverso da
                    //quello inserito perchè fake mackaroo
                    p = await GetProductAsync(url.PathAndQuery);
                    if (p != null)
                        ShowProduct(p);
                }
            }
            */
            #endregion

            #region TEST PUT
            Product? p1 = new Product()
            {
                Id = 23,
                Name = "Pere",
                Price = 205,
                CompanyID = 34
            };
            /*
            Console.WriteLine("Update product");
            Console.WriteLine("Aggiorna prezzo prodotto");
            Product? updateProduct = await PutProductAsync(p1);
            if (updateProduct != null)
            {
                ShowProduct(updateProduct);
            }
            */
            #endregion

            #region TEST DELETE
            //var statusCode = await DeleteProductAsync(p1.Id);
            //Console.WriteLine($"Deleted (HTTP Status = {(int)statusCode})");
            #endregion

            #region Test Companies
            /*
            Console.WriteLine("Elenco di tutte le compagnie");
            var companies = await GetCompaniesAsync("/companies.json");
            if (companies != null)
            {
                JsonSerializerOptions options = new() { WriteIndented = true };
                companies.ForEach(c => Console.WriteLine(JsonSerializer.Serialize(c, options) + "\n"));
            }
            */
            #endregion
        }

        #region Api Product
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

        static async Task<Uri?> PostProductAsync(Product p)
        {
            var response = await client.PostAsJsonAsync("/Products.json", p);
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

        static async Task<Product?> PutProductAsync(Product product)
        {
            HttpResponseMessage message = await client.PutAsJsonAsync($"Products/{product.Id}.json", product);
            message.EnsureSuccessStatusCode();
            // la put restituisce il prodotto aggiornato che viene deserializzato
            Product? productUpdate = await message.Content.ReadFromJsonAsync<Product?>();
            return productUpdate;
        }

        static async Task<HttpStatusCode> DeleteProductAsync(int id)
        {
            string path = $"Products/{id}.json";
            HttpResponseMessage response = await client.DeleteAsync(path);
            return response.StatusCode;
        }

        static void ShowProducts(List<Product> products)
        {
            products.ForEach(p => ShowProduct(p));
        }

        static void ShowProduct(Product product)
        {
            Console.WriteLine(product);
        }

        static async Task<Uri?> PostProductAsync2(Product p)
        {
            //serializza prodotto
            string data = JsonSerializer.Serialize(p);
            var content = new StringContent(data, Encoding.UTF8, "application/json");
            //faccio la Post asincrona dello StringContent
            var response = await client.PostAsync($"Products.json", content);
            //verifico che l'operazione sia andata a buon fine
            response.EnsureSuccessStatusCode();

            //sull'oggetto response posso fare diverse elaborazioni
            //se il server restituisce l'oggetto creato, posso recuperarlo dal body della risposta
            Product? prodottoCreato = await response.Content.ReadFromJsonAsync<Product>();
            Console.WriteLine("Prodotto creato:\n" + JsonSerializer.Serialize(prodottoCreato));
            //oppure posso leggere il body della risposta come stringa e poi elaborarla
            string prodottoCreatoAsString = await response.Content.ReadAsStringAsync();
            Product? prodotto = JsonSerializer.Deserialize<Product>(prodottoCreatoAsString);
            Console.WriteLine("Prodotto creato come stringa\n" + prodottoCreatoAsString);
            //return URI of the created resource.
            Console.WriteLine("Headers location: " + response.Headers.Location);
            return response.Headers.Location;
        }

        #endregion

        #region Api Companies
        static async Task<List<Company?>> GetCompaniesAsync(string path)
        {
            await using Stream stream = await client.GetStreamAsync(path);
            var companies = await JsonSerializer.DeserializeAsync<List<Company>>(stream);
            return companies;
        }
        static async Task<Company?> GetCompanyAsync(string path)
        {
            var company = await client.GetFromJsonAsync<Company>(path);
            return company;
        }
        static async Task<List<Company>?> GetAllCompaniesAsync2(string path)
        {
            HttpResponseMessage response = await client.GetAsync(path);
            string? companies = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<Company>?>(companies);
        }
        static async Task<List<Company>?> GetAllCompaniesAsync3(string path)
            => await client.GetFromJsonAsync<List<Company>>(path);

        #endregion

        static async Task Main(string[] args)
        {
            MyProxy.HttpClientProxySetup(out client);
            //Console.WriteLine(GetKeyFromStore());
            await RunAsync();
        }
    }
}