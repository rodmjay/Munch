using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using MunchBase.Administration.Interfaces;
using MunchBase.Channels.Entities;
using MunchBase.Channels.Extensions;
using MunchBase.Channels.Interfaces;
using MunchBase.Channels.ViewModels;
using MunchBase.Common.Data.Interfaces;
using MunchBase.Common.Extensions;
using MunchBase.Common.Models;
using MunchBase.Common.Services.Bases;
using MunchBase.Consumers.Interfaces;
using MunchBase.Editors.Interfaces;
using MunchBase.Models.Interfaces;
using MunchBase.Producers.Entities;
using MunchBase.Producers.ViewModels;
using MunchBase.Providers.Entities;

namespace MunchBase.Channels.Services;

public partial class ChannelService : BaseService<Channel>, IChannelService
{
    private readonly IRepositoryAsync<Producer> _producerRepo;
    private readonly IRepositoryAsync<Provider> _providerRepo;

    public ChannelService(IServiceProvider serviceProvider, 
        IRepositoryAsync<Producer> producerRepo,
        IRepositoryAsync<Provider> providerRepo) : base(serviceProvider)
    {
        _producerRepo = producerRepo;
        _providerRepo = providerRepo;
    }

    public IQueryable<Provider> Providers => _providerRepo.Queryable();
    public IQueryable<Channel> Channels => Repository.Queryable();
    public IQueryable<Producer> Producers => _producerRepo.Queryable();

    public Task<PagedList<T>> GetChannels<T>(IAdmin admin, PagingQuery paging, ChannelQuery query) where T : ChannelDto
    {
        return this.PaginateAsync<Channel, T>(query.GetExpression(), paging);
    }

    public Task<T> GetChannel<T>(IAdmin admin, int channelId) where T : ChannelDto
    {
        return Channels.Where(x => x.Id == channelId).ProjectTo<T>(ProjectionMapping)
            .FirstAsync();
    }

    public Task<T> GetChannel<T>(IConsumer consumer, int channelId) where T : ChannelDto
    {
        return Channels.Where(x => x.Id == channelId).ProjectTo<T>(ProjectionMapping)
            .FirstAsync();
    }

    public Task<T> GetChannel<T>(IProducer producer, int channelId) where T : ChannelDto
    {
        return Channels.Where(x => x.Id == channelId).ProjectTo<T>(ProjectionMapping)
            .FirstAsync();
    }

    public Task<T> GetChannel<T>(IModel model, int channelId) where T : ChannelDto
    {
        return Channels.Where(x => x.Id == channelId).ProjectTo<T>(ProjectionMapping)
            .FirstAsync();
    }

    public Task<T> GetChannel<T>(IEditor editor, int channelId) where T : ChannelDto
    {
        return Channels.Where(x => x.Id == channelId).ProjectTo<T>(ProjectionMapping)
            .FirstAsync();
    }

    public Task<Result> Subscribe(IConsumer consumer, int channelId)
    {
        throw new NotImplementedException();
    }

    public Task<Result> Unsubscribe(IConsumer consumer, int channelId)
    {
        throw new NotImplementedException();
    }

    public Task<T> GetChannel<T>(int adminId, int channelId) where T : ChannelDto
    {
        throw new NotImplementedException();
    }
}