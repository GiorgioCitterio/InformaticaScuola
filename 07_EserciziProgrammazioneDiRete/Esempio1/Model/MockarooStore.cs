using System.Text.Json.Serialization;

namespace Esempio1.Model
{
    public class MockarooStore
    {
        [JsonPropertyName("api_key")]
        public string? APIKeyValue { get; set; }
        [JsonPropertyName("base_address")]
        public string? BaseAddress { get; set; }
    }
}