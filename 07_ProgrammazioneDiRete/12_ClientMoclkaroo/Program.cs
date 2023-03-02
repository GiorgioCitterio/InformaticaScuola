using SettingProxy;
using System.Net.Http.Headers;

namespace _12_ClientMockaroo
{
    public class Program
    {
        const string APIKeyName = "X-API-Key";
        readonly static string APIKeyValue = GetKeyFromStore();
        static string baseAddress = "https://my.api.mockaroo.com";
        static string acceptedMediaType = "application/json";
        static HttpClient client;

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
        }
        static async Task Main(string[] args)
        {
            MyProxy.HttpClientProxySetup(out client);
            Console.WriteLine(GetKeyFromStore());
        }
    }
}