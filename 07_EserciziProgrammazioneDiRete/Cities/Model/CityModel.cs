using System.Text.Json.Serialization;

namespace Cities.Model
{
    public class CityModel
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("country_code")]
        public string? CountryCode { get; set; }
    }
}
