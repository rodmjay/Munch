using Microsoft.AspNetCore.Mvc;
using MunchBase.Providers.Interfaces;
using MunchBase.Providers.ViewModels;

namespace Munch.AdminApi.Controllers;

public class ProvidersController : BaseAdminController
{
    private readonly IProviderService _service;

    public ProvidersController(IServiceProvider serviceProvider, IProviderService service) : base(serviceProvider)
    {
        _service = service;
    }

    [HttpGet]
    public Task<List<ProviderDto>> GetProviders()
    {
        return _service.GetProviders<ProviderDto>(Admin);
    }
}