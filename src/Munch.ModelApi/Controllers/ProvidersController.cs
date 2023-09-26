using Microsoft.AspNetCore.Mvc;
using MunchBase.Common.Models;
using MunchBase.Models.ViewModels;
using MunchBase.Providers.Interfaces;
using MunchBase.Providers.ViewModels;

namespace Munch.ModelApi.Controllers
{
    public class ProvidersController : BaseModelController
    {
        private readonly IProviderService _service;

        public ProvidersController(IServiceProvider serviceProvider, IProviderService service) : base(serviceProvider)
        {
            _service = service;
        }

        [HttpGet]
        public Task<List<ModelProviderDto>> GetProviders()
        {
            return _service.GetProviders<ModelProviderDto>(Model);
        }

        [HttpPost]
        public Task<Result> EnableProvider([FromBody] ModelProviderInput input)
        {
            return _service.EnableProvider(Model, input.ProviderId, input.Username);
        }

        [HttpDelete("{providerId}")]
        public Task<Result> RemoveProvider([FromRoute]int providerId)
        {
            return _service.DisableProvider(Model, providerId);
        }
    }
}
