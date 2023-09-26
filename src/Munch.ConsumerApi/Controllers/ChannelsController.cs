using Microsoft.AspNetCore.Mvc;
using MunchBase.Channels.Interfaces;
using MunchBase.Channels.ViewModels;
using MunchBase.Common.Models;

namespace Munch.ConsumerApi.Controllers
{
    public class ChannelsController : BaseConsumerController, IReadChannels<ChannelDto>
    {
        private readonly IChannelService _service;
        protected ChannelsController(
            IServiceProvider serviceProvider, IChannelService service) : base(serviceProvider)
        {
            _service = service;
        }

        [HttpGet]
        public Task<PagedList<ChannelDto>> GetChannels([FromQuery] PagingQuery paging, [FromQuery] ChannelQuery query)
        {
            return _service.GetChannels<ChannelDto>(Consumer, paging, query);
        }

        [HttpGet("{channelId}")]
        public Task<ChannelDto> GetChannel(int channelId)
        {
            return _service.GetChannel<ChannelDto>(Consumer, channelId);
        }

        [HttpPatch("{channelId}/subscribe")]
        public Task<Result> Subscribe([FromRoute]int channelId)
        {
            return _service.Subscribe(Consumer, channelId);
        }


        [HttpDelete("{channelId}/subscribe")]
        public Task<Result> Unsubscribe([FromRoute]int channelId)
        {
            return _service.Unsubscribe(Consumer, channelId);
        }
    }
}
