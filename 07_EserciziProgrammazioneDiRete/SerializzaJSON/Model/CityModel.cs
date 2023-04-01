using System.Text.Json.Serialization;

namespace SerializzaJSON.Model
{
    public class CityModel
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }
    }
}
