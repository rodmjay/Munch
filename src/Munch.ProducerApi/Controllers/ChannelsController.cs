using Microsoft.AspNetCore.Mvc;
using MunchBase.Channels.Interfaces;
using MunchBase.Channels.ViewModels;
using MunchBase.Common.Models;

namespace Munch.ProducerApi.Controllers;

public class ChannelsController : BaseProducerController, IReadChannels<ChannelDto>
{
    private readonly IChannelService _service;

    protected ChannelsController(IServiceProvider serviceProvider, IChannelService service) : base(serviceProvider)
    {
        _service = service;
    }

    [HttpGet]
    public Task<PagedList<ChannelDto>> GetChannels([FromQuery] PagingQuery paging, [FromQuery] ChannelQuery query)
    {
        return _service.GetChannels<ChannelDto>(Producer, paging, query);
    }

    [HttpGet("{channelId}")]
    public Task<ChannelDto> GetChannel(int channelId)
    {
        return _service.GetChannel<ChannelDto>(Producer, channelId);
    }
}