using SettingProxy;
namespace _04_DownloadFile
{
    public class Program
    {
        static HttpClient client;
        static async Task<int> ProcessUrlAsync(string url, HttpClient client)
        {
            var byteArray = await client.GetByteArrayAsync(url);
            //visualizza risultato
            return byteArray.Length;
        }
        static async Task DownloadAsync()
        {
            MyProxy.HttpClientProxySetup(out client);
            client.MaxResponseContentBufferSize= 10000000;
            Task<int> var1 = ProcessUrlAsync("https://docs.microsoft.com/en-us/welcome-to-docs", client);
            int var2 = await ProcessUrlAsync("https://istitutogreppi.edu.it", client);
            int var3 = await ProcessUrlAsync("https://google.it", client);
            int totale = await var1 + var2 + var3;
            Console.WriteLine(totale);
        }
        static async Task Main(string[] args)
        {
            await DownloadAsync();
        }
    }
}