using System.Text.Json;

namespace _08_EsempioSerializzazioneJSON
{
    //classe come modello di dati
    public class WeatherForecast
    {
        public DateTimeOffset Date { get; set; }
        public int TemperatureCelsius { get; set; }
        public string? Summary { get; set; }
    }

    public class Program
    {
        static async Task JsonDemoAsync()
        {
            var weatherForecast = new WeatherForecast
            {
                Date = DateTime.Parse("2019-08-01"),
                TemperatureCelsius = 25,
                Summary = "Hot"
            };
            var weatherForecast2 = new WeatherForecast
            {
                Date = DateTime.Parse("2019-08-02"),
                TemperatureCelsius = 30,
                Summary = "Very Hot"
            };
            //lista di oggetti
            List<WeatherForecast> previsioni = new() { weatherForecast, weatherForecast2 };
            //serializzazione: da oggetto .NET a oggetto JSON
            var options = new JsonSerializerOptions { WriteIndented = true }; //opzione per indentare json
            string jsonString = JsonSerializer.Serialize(previsioni, options); //serializza e restituisce una stringa
            Console.WriteLine(jsonString);
            //serializza su file
            string nomeFile = "Previsione.json";
            FileStream fileStream = File.Create(nomeFile);
            JsonSerializer.Serialize(fileStream, previsioni, options);
            await fileStream.DisposeAsync();
            //leggo il file serializzato
            Console.WriteLine("file letto da disco");
            Console.WriteLine(await File.ReadAllTextAsync(nomeFile));
        }
        static async Task Main(string[] args)
        {
            await JsonDemoAsync();
        }
    }
}