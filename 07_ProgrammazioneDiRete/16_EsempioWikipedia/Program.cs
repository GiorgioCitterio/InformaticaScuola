using SettingProxy;
using System.Text;
using System.Text.Json;

namespace _16_EsempioWikipedia
{
    internal class Program
    {
        static HttpClient client;
        static async Task Main(string[] args)
        {
            MyProxy.HttpClientProxySetup(out client);
            string wikiUrl = "https://it.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&exsectionformat=plain&redirects=1&titles=Dante_Alighieri";
            string wikiSummaryJSON = await client.GetStringAsync(wikiUrl);
            //Console.WriteLine(wikiSummaryJSON);
            string summary = ExtractSummaryFromJSON(wikiSummaryJSON);
            Console.OutputEncoding = Encoding.Unicode;
            Console.WriteLine(summary);
        }

        private static string ExtractSummaryFromJSON(string wikiSummaryJSON)
        {
            using JsonDocument document = JsonDocument.Parse(wikiSummaryJSON);
            JsonElement root = document.RootElement;
            JsonElement query = root.GetProperty("query");
            JsonElement pages = query.GetProperty("pages");
            JsonElement.ObjectEnumerator enumerator = pages.EnumerateObject();
            if (enumerator.MoveNext()) 
            {
                JsonElement target = enumerator.Current.Value;
                if(target.TryGetProperty("extract", out JsonElement extract))
                {
                    return extract.GetString() ?? string.Empty;
                }
            }
            return string.Empty;
        }
    }
}