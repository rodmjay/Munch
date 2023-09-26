using System.Threading.Tasks;
using MunchBase.Channels.Entities;
using MunchBase.Channels.Extensions;
using MunchBase.Channels.ViewModels;
using MunchBase.Common.Extensions;
using MunchBase.Common.Models;
using MunchBase.Consumers.Interfaces;
using MunchBase.Editors.Interfaces;
using MunchBase.Models.Interfaces;
using MunchBase.Producers.ViewModels;

namespace MunchBase.Channels.Services;

public partial class ChannelService
{
    public Task<PagedList<T>> GetChannels<T>(IConsumer consumer, PagingQuery paging, ChannelQuery query)
        where T : ChannelDto
    {
        return GetChannels<T>(paging, query);
    }

    public Task<PagedList<T>> GetChannels<T>(IProducer producer, PagingQuery paging, ChannelQuery query)
        where T : ChannelDto
    {
        return GetChannels<T>(paging, query);
    }

    public Task<PagedList<T>> GetChannels<T>(IEditor editor, PagingQuery paging, ChannelQuery query)
        where T : ChannelDto
    {
        return GetChannels<T>(paging, query);
    }

    public Task<PagedList<T>> GetChannels<T>(IModel model, PagingQuery paging, ChannelQuery query) where T : ChannelDto
    {
        return GetChannels<T>(paging, query);
    }

    private Task<PagedList<T>> GetChannels<T>(PagingQuery paging, ChannelQuery query) where T : ChannelDto
    {
        return this.PaginateAsync<Channel, T>(query.GetExpression(), paging);
    }
}