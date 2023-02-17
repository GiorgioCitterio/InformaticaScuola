using SettingProxy;
using System.IO;

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
            Console.WriteLine("*****************************************************");
            Console.WriteLine(response.Content.Headers.ToString());

            string contenuto = await response.Content.ReadAsStringAsync();
            string contVilla = await client.GetStringAsync("https://www.vincenzov.net/");
            string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + Path.DirectorySeparatorChar + "index.html";
            File.WriteAllText(path, contVilla);
            await File.WriteAllTextAsync(path, contVilla);

            Console.WriteLine(contVilla);
            //Console.WriteLine(contenuto);
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
            //await DatiHeader("https://istitutogreppi.edu.it");
            await DatiHeader("https://www.vincenzov.net/");
        }
    }
}