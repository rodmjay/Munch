using Microsoft.AspNetCore.Mvc;
using MunchBase.Common.Models;
using MunchBase.Consumers.Interfaces;
using MunchBase.Consumers.ViewModels;

namespace Munch.AdminApi.Controllers;

public class ConsumersController : BaseAdminController
{
    private readonly IConsumerService _service;

    public ConsumersController(IServiceProvider serviceProvider, IConsumerService service) : base(serviceProvider)
    {
        _service = service;
    }

    [HttpGet]
    public Task<PagedList<ConsumerDto>> GetConsumers([FromQuery] ConsumerQuery query, [FromQuery] PagingQuery paging)
    {
        return _service.GetConsumers<ConsumerDto>(Admin, query, paging);
    }

    [HttpGet("{consumerId}")]
    public Task<ConsumerDto> GetConsumer(int consumerId)
    {
        return _service.GetConsumer<ConsumerDto>(Admin, consumerId);
    }
}