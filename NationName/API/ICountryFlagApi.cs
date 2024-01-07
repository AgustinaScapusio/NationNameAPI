using NationName.Models;
using System.Text.Json.Serialization;

namespace NationName.API
{
    public interface ICountryFlagApi
    {
        Task<CountryFlagResponse[]> GetCountryFlagAsync(string countryCode);
    }

    public class CountryFlagApi : ICountryFlagApi
    {
        private readonly HttpClient _httpClient;

        public CountryFlagApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CountryFlagResponse[]> GetCountryFlagAsync(string countryCode)
        {
            var response = await _httpClient.GetAsync($"https://restcountries.com/v3.1/alpha/{countryCode}");
            return await response.Content.ReadFromJsonAsync<CountryFlagResponse[]>();
        }
    }
}
