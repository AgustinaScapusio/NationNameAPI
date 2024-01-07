using System.Text.Json.Serialization;

namespace NationName.Models
{
    public class Country
    {
        [JsonPropertyName("country_id")]
        public string Id { get; set; }


        [JsonPropertyName("probability")]
        public decimal Probability { get; set; }

    }
}