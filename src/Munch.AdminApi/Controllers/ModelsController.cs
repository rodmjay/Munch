using Microsoft.AspNetCore.Mvc;
using MunchBase.Common.Models;
using MunchBase.Models.Interfaces;
using MunchBase.Models.ViewModels;

namespace Munch.AdminApi.Controllers;

public class ModelsController : BaseAdminController
{
    private readonly IFeaturedModelService _featuredModelService;
    private readonly IModelService _service;
    public ModelsController(
        IFeaturedModelService featuredModelService,
        IServiceProvider serviceProvider,
        IModelService service) : base(serviceProvider)
    {
        _featuredModelService = featuredModelService;
        _service = service;
    }

    [HttpGet]
    public Task<PagedList<ModelDto>> GetModels([FromQuery] PagingQuery paging, [FromQuery] ModelQuery query)
    {
        return _service.GetModels<ModelDto>(Admin, paging, query);
    }

    [HttpGet("{modelId}")]
    public Task<ModelDetailsDto> GetModel([FromRoute]int modelId)
    {
        return _service.GetModel<ModelDetailsDto>(Admin, modelId);
    }

    [HttpPatch("{modelId}/feature")]
    public Task<Result> FeatureModel([FromRoute] int modelId)
    {
        return _featuredModelService.FeatureModel(Admin, modelId);
    }
}