using Microsoft.AspNetCore.Mvc;
using MunchBase.Common.Models;
using MunchBase.Models.Interfaces;
using MunchBase.Models.ViewModels;

namespace Munch.EditorApi.Controllers;

public class ModelsController : BaseEditorController
{
    private readonly IModelService _service;
    public ModelsController(
        IServiceProvider serviceProvider, IModelService service) : base(serviceProvider)
    {
        _service = service;
    }

    [HttpGet]
    public Task<PagedList<ModelDto>> GetModels([FromQuery]PagingQuery paging, [FromQuery] ModelQuery query)
    {
        return _service.GetModels<ModelDto>(Editor, paging, query);
    }


    [HttpGet("{modelId}")]
    public Task<ModelDto> GetModel([FromRoute] int modelId)
    {
        return _service.GetModel<ModelDto>(Editor, modelId);
    }
}