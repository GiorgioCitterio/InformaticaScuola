using System.Text.Json.Serialization;

namespace _12_ClientMoclkaroo.Model
{
    public class Product
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName ("name")]
        public string? Name { get; set; }
        [JsonPropertyName ("price")]
        public float Price { get; set; }
        [JsonPropertyName("company_id")]
        public int CompanyID { get; set; }

        public override string? ToString()
        {
            return "id: " + Id + " nome: " + Name + " prezzo: " + Price + " id-compagnia: " + CompanyID;
        }
    }
}
