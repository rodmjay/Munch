using Microsoft.AspNetCore.Mvc;
using MunchBase.Common.Models;
using MunchBase.Media.Interfaces;
using MunchBase.Media.ViewModels;

namespace Munch.AdminApi.Controllers;

public class MediaSetsController : BaseAdminController, IReadMediaSets<MediaSetDto>
{
    private readonly IMediaSetService _service;

    public MediaSetsController(IServiceProvider serviceProvider, IMediaSetService service) : base(serviceProvider)
    {
        _service = service;
    }

    [HttpGet]
    public Task<PagedList<MediaSetDto>> GetMediaSets([FromQuery] PagingQuery paging, [FromQuery]MediaSetQuery query)
    {
        return _service.GetMediaSets<MediaSetDto>(Admin, query, paging);
    }

    [HttpGet("{mediaSetId}")]
    public Task<MediaSetDto> GetMediaSet([FromRoute]int mediaSetId)
    {
        return _service.GetMediaSet<MediaSetDto>(Admin, mediaSetId);
    }
}