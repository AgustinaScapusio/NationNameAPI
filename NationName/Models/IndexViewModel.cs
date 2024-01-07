using System.Text.Json.Serialization;

namespace NationName.Models
{
    public class IndexViewModel
    {
        public string Name { get; set; }
        public int Count { get; set; }
        public CountryResponse CountryResponse { get; set; } = new();
        public Name CountryCode { get; set; }
        public CountryFlagResponse[] CountryFlagResponse { get; set; }

    }

}
