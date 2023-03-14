using Esempio1.Model;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace Esempio1
{
    internal class Program
    {
        static HttpClient? client = new HttpClient();
        const string APIKeyName = "X-API-Key";
        static MockarooStore store = GetKeyFromJsonStore();
        static readonly string? APIKeyValue = store.APIKeyValue;
        static string? baseAddress = store.BaseAddress;
        static string? acceptedMediaType = "application/json";
        const string PATH = "Esempio1.json";
        static async Task<List<Person>> GetPersonsAsync(string path)
        {
            //Stream? stream = await client.GetStreamAsync(path);
            //var persons = await JsonSerializer.DeserializeAsync<List<Person>>(stream);
            var persons = await client.GetFromJsonAsync<List<Person>>(path);
            return persons;
        }
        static async Task PostPersonAsync(Person person)
        {
            var httpResponseMessage = await client.PostAsJsonAsync("/Esempio1.json", person);
            if(httpResponseMessage.IsSuccessStatusCode)
            {
                Person pNuova = await httpResponseMessage.Content.ReadFromJsonAsync<Person>();
                ShowPerson(pNuova);
            }
        }
        private static void ShowPersons(List<Person> people)
        {
            people.ForEach(person => ShowPerson(person));
        }
        private static void ShowPerson(Person person)
        {
            Console.WriteLine(person.FirstName + " " + person.LastName + " " + person.Email + " " + person.Id);
        }

        static async Task Main(string[] args)
        {
            await RunAsync();
        }
        static async Task RunAsync()
        {
            client.BaseAddress = new Uri(baseAddress);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(acceptedMediaType));
            client.DefaultRequestHeaders.Add(APIKeyName, APIKeyValue);
            var persons = await GetPersonsAsync(PATH);
            ShowPersons(persons);
            Person p = new Person()
            {
                Email = "df",
                FirstName = "sa",
                LastName = "dfs",
                Id = 1
            };
            await PostPersonAsync(p);
        }
        private static MockarooStore GetKeyFromJsonStore()
        {
            string path = "../../../../../../../MockarooKeys/MockKey.json";
            string store = File.ReadAllText(path);
            MockarooStore? mockarooStore = JsonSerializer.Deserialize<MockarooStore>(store);
            return mockarooStore ?? new MockarooStore();
        }
        private static string GetKeyFromTxtFile()
        {
            string path = "../../../../../../MockarooKeys/MockKey.txt";
            string key = File.ReadAllText(path);
            return key;
        }
    }
}