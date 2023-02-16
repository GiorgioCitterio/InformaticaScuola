using SettingProxy;
using System.Diagnostics;

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
            Task<int> var1 = ProcessUrlAsync("https://google.it", client);
            int var2 = await ProcessUrlAsync("https://istitutogreppi.edu.it", client);
            int var3 = await ProcessUrlAsync("https://google.it", client);
            int totale = await var1 + var2 + var3;
            Console.WriteLine(totale);
        }

        static List<string> SetUpURLList()
        {
            List<string> urls = new List<string>
                    {
                    "https://google.it",
                    "https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/async/",
                    "https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/",
                    "https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/linq-to-objects",
                    "https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/linq-and-strings",
                    "https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/linq-to-xml-overview",
                    "https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/async/async-return -types",
                    "https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/ linq / linq - to - xml - vs - dom",
                    "https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/ reflection"
};
            return urls;
        }
        static async Task<int> ProcessURLAsync1(string url, HttpClient client)
        {
            var sw = new Stopwatch();
            sw.Start();
            var byteArray = await client.GetByteArrayAsync(url);
            sw.Stop();
            DisplayResults(url, "https://docs.microsoft.com/en-us/",byteArray, sw.ElapsedMilliseconds);
            return byteArray.Length;
        }
        static void DisplayResults(string url, string urlHeadingStrip, byte[] content, long elapsedMillis)
        {
            var bytes = content.Length;
            var displayURL = url.Replace(urlHeadingStrip, "");
            Console.WriteLine($"\n{displayURL,-80} bytes: {bytes,-10} ms: {elapsedMillis,-10}");
        }
        public static async Task SumPageSizeAsync()
        {
            MyProxy.HttpClientProxySetup(out client);
            List<string> url = SetUpURLList();
            var swGlobal = new Stopwatch();
            swGlobal.Start();
            IEnumerable<Task<int>> downloadTasks = url.Select(url => ProcessURLAsync1(url, client));
            int[] risultato = await Task.WhenAll(downloadTasks);
            swGlobal.Stop();
            Console.WriteLine($"\r\n\r\nTotal bytes returned: {risultato.Sum()}\r\n");
            Console.WriteLine($"Tempo complessivo di scaricamento = {swGlobal.ElapsedMilliseconds}");
        }
        static async Task Main(string[] args)
        {
            //await DownloadAsync();
            await SumPageSizeAsync();
        }
    }
}