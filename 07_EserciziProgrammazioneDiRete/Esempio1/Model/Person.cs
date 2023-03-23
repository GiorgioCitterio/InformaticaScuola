using System.Text.Json.Serialization;
namespace Esempio1.Model
{
    public class Person
    {
        [JsonPropertyName("id")]
        public int? Id { get; set; }

        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }

        [JsonPropertyName("last_name")]
        public string LastName { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }
        public override string ToString()
        {
            return Id + " " + FirstName + " " + LastName + " " + Email;
        }
    }
}