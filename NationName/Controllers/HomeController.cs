using Microsoft.AspNetCore.Mvc;
using NationName.API;
using NationName.Models;
using System.Diagnostics;

namespace NationName.Controllers
{
    public class HomeController : Controller
    {
        private readonly INationAPI _nationAPI;
        private readonly ICountryFlagApi _countryAPI;

        public HomeController(INationAPI nationAPI, ICountryFlagApi countryAPI)
        {
            _countryAPI = countryAPI;
            _nationAPI = nationAPI;
        }
        [HttpGet("/")]
        public IActionResult Index()
        {
            return View(new IndexViewModel() );
        }

      
        [HttpPost("/")]
        public async Task<IActionResult> Index(IndexViewModel model)
        {
            var country = await _nationAPI.GetCountryAsync(model.Name);
            model.CountryResponse = country;

            if (country != null && country.Country != null && country.Country.Any())
            {
                var countryFlagResponses = new List<CountryFlagResponse>();
                foreach (var country1 in model.CountryResponse.Country)
                {
                    var code = await _countryAPI.GetCountryFlagAsync(country1.Id);

                    if (code != null && code.Length > 0)
                    {
                        countryFlagResponses.Add(code[0]);
                    }
                }
                model.CountryFlagResponse = countryFlagResponses.ToArray();
            }
            else
            {
                Console.WriteLine("Failed to retrieve country data from Nationalize API.");
            }

            return View(model);
        }
    }
}
