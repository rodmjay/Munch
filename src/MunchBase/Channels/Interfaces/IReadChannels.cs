using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MunchBase.Channels.ViewModels;
using MunchBase.Common.Models;

namespace MunchBase.Channels.Interfaces;

public interface IReadChannels<T> where T : ChannelDto
{
    Task<PagedList<T>> GetChannels([FromQuery] PagingQuery paging, [FromQuery] ChannelQuery query);
    Task<T> GetChannel(int channelId);
}