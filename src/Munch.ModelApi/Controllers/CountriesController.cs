using Microsoft.AspNetCore.Mvc;
using MunchBase.Common.Models;
using MunchBase.Models.Interfaces;

namespace Munch.ModelApi.Controllers
{
    public class CountriesController : BaseModelController
    {
        private readonly IModelExcludeCountryService _excludeCountryService;

        public CountriesController(IServiceProvider serviceProvider, 
            IModelExcludeCountryService excludeCountryService) : base(serviceProvider)
        {
            _excludeCountryService = excludeCountryService;
        }

        [HttpPatch("exclude/{iso3}")]
        public Task<Result> ExcludeCountry(string iso3)
        {
            return _excludeCountryService.ExcludeCountry(1, iso3);
        }

        [HttpDelete("exclude/{iso3}")]
        public Task<Result> DeleteExcludedCountry(string iso3)
        {
            return _excludeCountryService.IncludeCountry(1, iso3);
        }
    }
}
