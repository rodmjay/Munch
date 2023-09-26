using Microsoft.AspNetCore.Mvc;
using MunchBase.Common.Models;
using MunchBase.Producers.Interfaces;
using MunchBase.Producers.ViewModels;

namespace Munch.AdminApi.Controllers;

public class ProducersController : BaseAdminController
{
    private readonly IProducerService _service;

    public ProducersController(IServiceProvider serviceProvider, IProducerService service) : base(serviceProvider)
    {
        _service = service;
    }

    [HttpGet]
    public Task<PagedList<ProducerDto>> GetProducers([FromQuery] ProducerQuery query, [FromQuery] PagingQuery paging)
    {
        return _service.GetProducers<ProducerDto>(Admin, query, paging);
    }

    [HttpGet("{producerId}")]
    public Task<ProducerDto> GetProducer(int producerId)
    {
        return _service.GetProducer<ProducerDto>(Admin, producerId);
    }
}