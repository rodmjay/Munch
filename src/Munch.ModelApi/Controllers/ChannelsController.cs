using Microsoft.AspNetCore.Mvc;
using MunchBase.Channels.Interfaces;
using MunchBase.Channels.ViewModels;
using MunchBase.Common.Models;

namespace Munch.ModelApi.Controllers
{
    public class ChannelsController : BaseModelController
    {
        private readonly IChannelService _service;

        public ChannelsController(
            IServiceProvider serviceProvider, IChannelService service) : base(serviceProvider)
        {
            _service = service;
        }

        [HttpGet]
        public Task<PagedList<ChannelDto>> GetChannels([FromQuery] PagingQuery paging, [FromQuery] ChannelQuery query)
        {
            return _service.GetChannels<ChannelDto>(Model, paging, query);
        }

        [HttpGet("{channelId}")]
        public Task<ChannelDto> GetChannel(int channelId)
        {
            return _service.GetChannel<ChannelDto>(Model, channelId);
        }

    }
}
