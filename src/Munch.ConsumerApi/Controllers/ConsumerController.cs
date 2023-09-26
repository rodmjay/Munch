using Microsoft.AspNetCore.Mvc;
using MunchBase.Consumers.Interfaces;
using MunchBase.Consumers.ViewModels;

namespace Munch.ConsumerApi.Controllers;

public class ConsumerController : BaseConsumerController
{
    private readonly IConsumerService _service;

    public ConsumerController(
        IServiceProvider serviceProvider, IConsumerService service) : base(serviceProvider)
    {
        _service = service;
    }

    [HttpGet]
    public Task<ConsumerDto> GetProfile()
    {
        return _service.GetConsumer<ConsumerDto>(Consumer);
    }
}