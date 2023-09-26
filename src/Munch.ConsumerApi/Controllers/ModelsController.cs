using Microsoft.AspNetCore.Mvc;
using Munch.ConsumerApi.ViewModels;
using MunchBase.Common.Models;
using MunchBase.Models.Interfaces;
using MunchBase.Models.ViewModels;

namespace Munch.ConsumerApi.Controllers;

public class ModelsController : BaseConsumerController
{
    private readonly IModelService _service;
    protected ModelsController(
        IServiceProvider serviceProvider, IModelService service) : base(serviceProvider)
    {
        _service = service;
    }

    [HttpGet]
    public Task<PagedList<ModelDto>> GetModels([FromQuery] PagingQuery paging, [FromQuery] ModelQuery query)
    {
        return _service.GetModels<ModelDto>(Consumer, paging, query);
    }

    [HttpGet("{modelId}")]
    public Task<ConsumerModelDetails> GetModel(int modelId)
    {
        return _service.GetModel<ConsumerModelDetails>(Consumer, modelId);
    }

    [HttpPatch("{modelId}/subscribe")]
    public Task<Result> Subscribe(int modelId)
    {
        return _service.Subscribe(Consumer, modelId);
    }


    [HttpDelete("{modelId}/subscribe")]
    public Task<Result> Unsubscribe(int modelId)
    {
        return _service.Unsubscribe(Consumer, modelId);
    }
}