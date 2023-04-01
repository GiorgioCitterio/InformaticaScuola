using System.Text.Json;
using System.Text.Json.Serialization;

namespace _01_SpeechRecognitionDemo
{
    public class AzureSpeechServiceStore
    {
        [JsonPropertyName("api_key")]
        public string APIKeyValue { get; set; } = string.Empty;

        [JsonPropertyName("region_location")]
        public string RegionLocation { get; set; } = string.Empty;

        [JsonPropertyName("endpoint")]
        public string EndPoint { get; set; } = string.Empty;
    }

    public class Program
    {
        static AzureSpeechServiceStore azureSpeechServiceStore = GetDataFromStore();
        static readonly string azureSpeechServiceKey = azureSpeechServiceStore.APIKeyValue;
        static readonly string azureSpeechServiceRegion = azureSpeechServiceStore.RegionLocation;
        static void Main(string[] args)
        {
            Console.WriteLine();
        }
        static AzureSpeechServiceStore GetDataFromStore()
        {
            string keyStorePath = "../../../../../../../MyAzureStore/MyAzureRoboVoiceStore.json";
            string store = File.ReadAllText(keyStorePath);
            AzureSpeechServiceStore? azureSpeechServiceStore = JsonSerializer.Deserialize<AzureSpeechServiceStore>(store);
            return azureSpeechServiceStore ?? new AzureSpeechServiceStore();
        }
    }
}