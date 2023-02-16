using SettingProxy;

namespace _05_AnalisiHeaders
{
    internal class Program
    {
        static HttpClient client;
        static async Task DatiHeader(string url)
        {
            MyProxy.HttpClientProxySetup(out client);
            HttpResponseMessage response = await client.GetAsync(url);
            Console.WriteLine("Status code: "+response.StatusCode);
            Console.WriteLine(response.Headers.ToString());
            //foreach (var key in response.Headers)
            //{
            //    Console.Write("Key: "+key.Key);
            //    foreach (var val in key.Value)
            //    {
            //        Console.WriteLine(val);
            //    }
            //}
        }
        static async Task Main(string[] args)
        {
            await DatiHeader("https://istitutogreppi.edu.it");
        }
    }
}