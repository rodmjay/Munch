using System.Threading.Tasks;

using MunchBase.Administration.Interfaces;
using MunchBase.Channels.ViewModels;
using MunchBase.Common.Models;
using MunchBase.Consumers.Interfaces;
using MunchBase.Editors.Interfaces;
using MunchBase.Models.Interfaces;
using MunchBase.Producers.ViewModels;

namespace MunchBase.Channels.Interfaces;

public interface IChannelService
{
    Task<PagedList<T>> GetChannels<T>(IAdmin admin, PagingQuery paging, ChannelQuery query) where T : ChannelDto;

    Task<PagedList<T>> GetChannels<T>(IConsumer consumer, PagingQuery paging, ChannelQuery query) where T : ChannelDto;
    Task<PagedList<T>> GetChannels<T>(IProducer producer, PagingQuery paging, ChannelQuery query) where T : ChannelDto;
    Task<PagedList<T>> GetChannels<T>(IEditor editor, PagingQuery paging, ChannelQuery query) where T : ChannelDto;
    Task<PagedList<T>> GetChannels<T>(IModel model, PagingQuery paging, ChannelQuery query) where T : ChannelDto;
    Task<T> GetChannel<T>(IAdmin admin, int channelId) where T : ChannelDto;
    Task<T> GetChannel<T>(IConsumer consumer, int channelId) where T : ChannelDto;
    Task<T> GetChannel<T>(IProducer producer, int channelId) where T : ChannelDto;
    Task<T> GetChannel<T>(IModel model, int channelId) where T : ChannelDto;
    Task<T> GetChannel<T>(IEditor editor, int channelId) where T : ChannelDto;
    Task<Result> Subscribe(IConsumer consumer, int channelId);
    Task<Result> Unsubscribe(IConsumer consumer, int channelId);
    Task<Result> CreateChannel(IAdmin admin, ChannelInput input);
}