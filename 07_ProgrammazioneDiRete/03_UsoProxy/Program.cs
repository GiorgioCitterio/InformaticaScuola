using SettingProxy;
namespace _03_UsoProxy
{
    internal class Program
    {
        static HttpClient client;
        static async void Main(string[] args)
        {
            MyProxy.HttpClientProxySetup(out client);
            try
            {
                HttpResponseMessage response = await client.GetAsync("https://google.it");
                response.EnsureSuccessStatusCode();
                string content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(content);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }           
        }   
    }
}