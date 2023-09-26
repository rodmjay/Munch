using Microsoft.AspNetCore.Mvc;
using MunchBase.Producers.Interfaces;
using MunchBase.Producers.ViewModels;

namespace Munch.ProducerApi.Controllers;

public class ProducerController : BaseProducerController
{
    private readonly IProducerService _service;

    protected ProducerController(IServiceProvider serviceProvider, IProducerService service) : base(serviceProvider)
    {
        _service = service;
    }

    [HttpGet]
    public Task<ProducerDto> GetProducer()
    {
        return _service.GetProducer<ProducerDto>(Producer);
    }
}