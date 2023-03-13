using Esempio1.Model;
using System.Text.Json;

namespace Esempio1
{
    internal class Program
    {
        static HttpClient? client;
        const string APIKeyName = "X-API-Key";
        static MockarooStore store = GetKeyFromJsonStore();
        static readonly string? ApiKeyValue = store.APIKeyValue;
        static string? baseAddress = store.BaseAddress;
        static string? acceptedMediaType = "application/json";
        const string PATH = "Esempio1";
        static async Task<List<Person>> GetPersonsAsync(string path)
        {
            Stream? stream = await client.GetStreamAsync(path);
            var persons = await JsonSerializer.DeserializeAsync<List<Person>>(stream);
            return persons;
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
            var persons = await GetPersonsAsync(PATH);
            ShowPersons(persons);
        }
        private static MockarooStore GetKeyFromJsonStore()
        {
            string path = "../../../../../../MockarooKeys/MockKey.json";
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