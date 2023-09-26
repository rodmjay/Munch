using Microsoft.AspNetCore.Mvc;
using Munch.ModelApi.ViewModels;
using MunchBase.Common.Models;
using MunchBase.Media.Interfaces;
using MunchBase.Media.ViewModels;

namespace Munch.ModelApi.Controllers
{
    public class MediaSetsController : BaseModelController, IReadMediaSets<MediaSetDto>
    {
        private readonly IMediaSetService _service;
        public MediaSetsController(
            IServiceProvider serviceProvider, IMediaSetService service) : base(serviceProvider)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<PagedList<MediaSetDto>> GetMediaSets([FromQuery] PagingQuery paging, [FromQuery] MediaSetQuery query)
        {
            var sets = await _service.GetMediaSets<MediaSetDto>(Model, query, paging);

            

            return sets;
        }

        [HttpGet("{mediaSetId}")]
        public Task<MediaSetDto> GetMediaSet(int mediaSetId)
        {
            var mediaSet = _service.GetMediaSet<MediaSetDto>(Model, mediaSetId);
            return mediaSet;
        }

        [HttpPost]
        public Task<Result> PublishMediaSet([FromBody]PublishMediaSetInput input)
        {
            return _service.PublishMediaSet(Model, input.ProviderId, input.MediaSetId);
        }
        
    }
}
