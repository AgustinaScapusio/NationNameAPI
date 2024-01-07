using System.Text.Json.Serialization;

namespace NationName.Models
{
    public class CountryFlagResponse
    {
        [JsonPropertyName("name")]
        public Name Name { get; set; }
    }
    public class Name
    {
        [JsonPropertyName("common")]
        public string Common { get; set; } = string.Empty;
    }
}
