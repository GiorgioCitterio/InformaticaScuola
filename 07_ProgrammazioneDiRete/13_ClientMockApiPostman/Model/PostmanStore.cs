using System.Text.Json.Serialization;

namespace _13_ClientMockApiPostman.Model
{
    public class PostmanStore
    {
        [JsonPropertyName("api_key")]
        public string? APIKeyValue { get; set; }

        [JsonPropertyName("base_address")]
        public string? BaseAddress { get; set; }

        public override string ToString()
        {
            return "api_key: " + APIKeyValue + " base_address: " + BaseAddress;
        }
    }
}
