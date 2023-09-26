using Microsoft.AspNetCore.Mvc;
using MunchBase.Common.Models;
using MunchBase.Models.ViewModels;

namespace Munch.ProducerApi.Controllers;

public class ModelsController : BaseProducerController
{
    protected ModelsController(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    [HttpGet]
    public Task<List<ModelDto>> GetModels([FromQuery] ModelQuery query, [FromQuery] PagingQuery paging)
    {
        throw new NotImplementedException();
    }
}