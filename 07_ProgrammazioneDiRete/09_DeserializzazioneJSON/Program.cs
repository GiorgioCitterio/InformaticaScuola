using System.Text.Json;

namespace _09_DeserializzazioneJSON
{
    public class WeatherForecast
    {
        public DateTimeOffset Date { get; set; }
        public int TemperatureCelsius { get; set; }
        public string? Summary { get; set; }
        public string? SummaryField;
        public IList<DateTimeOffset>? DatesAvailable { get; set; }
        public Dictionary<string, HighLowTemps>? TemperatureRanges { get; set; }
        public string[]? SummaryWords { get; set; }
    }

    public class HighLowTemps
    {
        public int High { get; set; }
        public int Low { get; set; }
    }

    public class Program
    {
        static void Esempio1Deserializzazione() //metodo sincrono
        {
            string jsonString =
                  @"{
                  ""Date"": ""2019-08-01T00:00:00-07:00"",
                  ""TemperatureCelsius"": 25,
                  ""Summary"": ""Hot"",
                  ""DatesAvailable"": [
                    ""2019-08-01T00:00:00-07:00"",
                    ""2019-08-02T00:00:00-07:00""],
                  ""TemperatureRanges"": {
                                ""Cold"": {
                                    ""High"": 20,
                                    ""Low"": -10},
                                ""Hot"": {
                                    ""High"": 60,
                                    ""Low"": 20}},
                  ""SummaryWords"":[
                    ""Cool"",
                    ""Windy"",
                    ""Humid""
                  ]
                }";
            //deserializzazione da json a .NET
            WeatherForecast? weatherForecast = JsonSerializer.Deserialize<WeatherForecast>(jsonString);
            Console.WriteLine(weatherForecast.TemperatureCelsius);
        }
        static void DeserializzaFile()
        {
            string nomeFile = "WeatherForecast.json";
            string jsonFile = File.ReadAllText(nomeFile);
            //Console.WriteLine(jsonFile);
            List<WeatherForecast>? weatherForecast = JsonSerializer.Deserialize<List<WeatherForecast>>(jsonFile);
            //Console.WriteLine(weatherForecast.TemperatureCelsius);
            foreach (var item in weatherForecast)
            {
                Console.WriteLine(item.TemperatureCelsius);
            }
        }
        static void Main(string[] args)
        {
            //Esempio1Deserializzazione();
            DeserializzaFile();
        }
    }
}