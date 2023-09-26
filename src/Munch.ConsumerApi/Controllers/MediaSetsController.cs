using Microsoft.AspNetCore.Mvc;
using MunchBase.Common.Models;
using MunchBase.Media.Interfaces;
using MunchBase.Media.ViewModels;

namespace Munch.ConsumerApi.Controllers
{
    public class MediaSetsController : BaseConsumerController, IReadMediaSets<MediaSetDto>
    {
        private readonly IMediaSetService _service;

        protected MediaSetsController(
            IServiceProvider serviceProvider, IMediaSetService service) : base(serviceProvider)
        {
            _service = service;
        }

        [HttpGet("{modelId}")]
        public Task<PagedList<MediaSetDto>> GetMediaSets(PagingQuery paging, MediaSetQuery query)
        {
            return _service.GetMediaSets<MediaSetDto>(Consumer, query, paging);
        }

        [HttpGet("{mediaSetId}")]
        public Task<MediaSetDto> GetMediaSet(int mediaSetId)
        {
            return _service.GetMediaSet<MediaSetDto>(Consumer, mediaSetId);
        }

        [HttpPatch("{photoSetId}/comment")]
        public Task<Result> AddComment([FromQuery] int photoSetId, [FromBody] string comment)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{photoSetId}/comment")]
        public Task<Result> RemoveComment(int photoSetId)
        {
            throw new NotImplementedException();
        }
    }
}
