using System.Text.Json.Serialization;

namespace _12_ClientMoclkaroo.Model
{
    public class Company
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string? Name { get; set; }
        [JsonPropertyName("revenue")]
        public float Revenue { get; set; }
        [JsonPropertyName("headquarter")]
        public Headquarter? Headquarter { get; set; }
        [JsonPropertyName("locations")]
        public Location[]? Locations { get; set; }
    }
    public class Headquarter
    {

        [JsonPropertyName("lon")]
        public float Lon { get; set; }
        [JsonPropertyName("lat")]
        public float Lat { get; set; }
    }
    public class Location
    {
        [JsonPropertyName("city")]
        public string? City { get; set; }
        [JsonPropertyName("employee_number")]
        public int Employees { get; set; }
        [JsonPropertyName("state")]
        public string? State { get; set; }
    }
}
