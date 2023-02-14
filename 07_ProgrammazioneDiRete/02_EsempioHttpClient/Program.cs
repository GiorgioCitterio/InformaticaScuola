using System.Net;
namespace _02_EsempioHttpClient
{
    public class Program
    {
        static readonly HttpClient httpClient = new HttpClient();
        static async void Main(string[] args)
        {
            HttpResponseMessage response = await httpClient.GetAsync("https://www.istitutogreppi.edu.it/");
            response.EnsureSuccessStatusCode();
        }
    }
}