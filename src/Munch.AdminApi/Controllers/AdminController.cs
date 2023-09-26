using Microsoft.AspNetCore.Mvc;
using MunchBase.Administration.Interfaces;
using MunchBase.Administration.ViewModels;

namespace Munch.AdminApi.Controllers;

public class AdminController : BaseAdminController
{
    private readonly IAdminService _service;

    public AdminController(
        IServiceProvider serviceProvider, IAdminService service) : base(serviceProvider)
    {
        _service = service;
    }

    [HttpGet]
    public Task<AdminDto> GetAdminProfile()
    {
        return _service.GetAdmin<AdminDto>(Admin);
    }
}