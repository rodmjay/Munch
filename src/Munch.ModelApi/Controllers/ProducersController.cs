using Microsoft.AspNetCore.Mvc;
using MunchBase.Common.Models;
using MunchBase.Producers.ViewModels;

namespace Munch.ModelApi.Controllers;

public class ProducersController : BaseModelController
{
    public ProducersController(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    [HttpGet]
    public Task<List<ProducerDto>> GetProducers([FromQuery] PagingQuery paging)
    {
        throw new NotImplementedException();
    }
}