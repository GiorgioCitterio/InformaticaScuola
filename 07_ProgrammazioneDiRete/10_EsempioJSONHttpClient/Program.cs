using SettingProxy;
using System.Net.Http.Json;
using _10_EsempioJSONHttpClient.Model;
using System.Text.Json;

namespace _10_EsempioJSONHttpClient
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }

        public override string? ToString()
        {
            return Id + " " + Name + " " + Username + " " + Email;
        }
    }

    public class Program
    {
        static HttpClient client;

        static async Task DeserializzaJsonAsync()
        {
            MyProxy.HttpClientProxySetup(out client);
            client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com");
            //User? user = await client.GetFromJsonAsync<User>("users/2");
            //Console.WriteLine(user);
            List<User>? users = await client.GetFromJsonAsync<List<User>>("users");
            users?.ForEach(u => Console.WriteLine(u));
        }

        static async Task SalvaToDoListAsync()
        {
            MyProxy.HttpClientProxySetup(out client);
            client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com");
            List<Todo>? todoList = await client.GetFromJsonAsync<List<Todo>>("/todos");
            //todoList?.ForEach(todoList => Console.WriteLine(todoList));
            var options = new JsonSerializerOptions { WriteIndented= true };
            string nomeFile = "todos.json";
            FileStream fileStream = File.Create(nomeFile);
            await JsonSerializer.SerializeAsync(fileStream, todoList, options);
            await fileStream.DisposeAsync();
        }

        static async Task Main(string[] args)
        {
            //await DeserializzaJsonAsync();
            await SalvaToDoListAsync();
        }
    }
}