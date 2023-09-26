using Microsoft.AspNetCore.Mvc;
using MunchBase.Channels.Interfaces;
using MunchBase.Channels.ViewModels;
using MunchBase.Common.Models;

namespace Munch.EditorApi.Controllers;

public class ChannelsController : BaseEditorController, IReadChannels<ChannelDto>
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
        return _service.GetChannels<ChannelDto>(Editor, paging, query);
    }

    [HttpGet("{channelId}")]
    public Task<ChannelDto> GetChannel([FromRoute]int channelId)
    {
        return _service.GetChannel<ChannelDto>(Editor, channelId);
    }

}