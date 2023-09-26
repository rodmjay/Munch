using Microsoft.AspNetCore.Mvc;
using MunchBase.Channels.Interfaces;
using MunchBase.Channels.ViewModels;
using MunchBase.Common.Models;

namespace Munch.AdminApi.Controllers
{
    public class ChannelsController : BaseAdminController, IReadChannels<ChannelDto>, ICreateChannel
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
            return _service.GetChannels<ChannelDto>(Admin, paging, query);
        }

        [HttpGet("{channelId}")]
        public Task<ChannelDto> GetChannel(int channelId)
        {
            return _service.GetChannel<ChannelDto>(Admin, channelId);
        }

        [HttpPost]
        public Task<Result> CreateChannel(ChannelInput input)
        {
            return _service.CreateChannel(Admin, input);
        }
    }
}
