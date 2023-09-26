using Microsoft.AspNetCore.Mvc;
using MunchBase.Common.Models;
using MunchBase.Media.Interfaces;
using MunchBase.Media.ViewModels;

namespace Munch.ProducerApi.Controllers;

public class MediaSetsController : BaseProducerController, IReadMediaSets<MediaSetDto>
{
    private readonly IMediaSetService _service;

    protected MediaSetsController(IServiceProvider serviceProvider, IMediaSetService service) : base(serviceProvider)
    {
        _service = service;
    }

    [HttpGet]
    public Task<PagedList<MediaSetDto>> GetMediaSets([FromQuery] PagingQuery paging, [FromQuery] MediaSetQuery query)
    {
        return _service.GetMediaSets<MediaSetDto>(Producer, query, paging);
    }

    [HttpGet("{mediaSetId}")]
    public Task<MediaSetDto> GetMediaSet(int mediaSetId)
    {
        return _service.GetMediaSet<MediaSetDto>(Producer, mediaSetId);
    }
}