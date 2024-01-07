using NationName.Models;
using System.Text.Json;

namespace NationName.API
{
    public interface INationAPI
    {
        Task<CountryResponse> GetCountryAsync(string name);
       
    }

    public class NationAPI : INationAPI
    {
        private readonly HttpClient _httpClient;
        public NationAPI(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<CountryResponse> GetCountryAsync(string name)
        {
            var response = await _httpClient.GetAsync($"https://api.nationalize.io/?name={name}");
            return await response.Content.ReadFromJsonAsync<CountryResponse>();
        }

        
       
    }
}
