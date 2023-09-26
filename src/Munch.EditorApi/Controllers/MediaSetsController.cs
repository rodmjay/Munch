using Microsoft.AspNetCore.Mvc;
using MunchBase.Common.Models;
using MunchBase.Media.Interfaces;
using MunchBase.Media.ViewModels;

namespace Munch.EditorApi.Controllers;

public class MediaSetsController : BaseEditorController, IReadMediaSets<MediaSetDto>, ICreateMediaSets
{
    private readonly IMediaSetService _service;

    public MediaSetsController(IServiceProvider serviceProvider, IMediaSetService service) : base(serviceProvider)
    {
        _service = service;
    }

    [HttpGet]
    public Task<PagedList<MediaSetDto>> GetMediaSets( [FromQuery]PagingQuery paging, [FromQuery] MediaSetQuery query)
    {
        return _service.GetMediaSets<MediaSetDto>(Editor, query, paging);
    }

    [HttpGet("{mediaSetId}")]
    public Task<MediaSetDto> GetMediaSet([FromRoute] int mediaSetId)
    {
        return _service.GetMediaSet<MediaSetDto>(Editor, mediaSetId);
    }

    [HttpPost]
    public Task<Result> CreateMediaSet([FromBody]MediaSetInput input)
    {
        return _service.CreateMediaSet(Editor, input);
    }
}