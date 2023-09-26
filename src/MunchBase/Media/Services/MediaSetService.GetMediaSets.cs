using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MunchBase.Administration.Interfaces;
using MunchBase.Common.Extensions;
using MunchBase.Common.Models;
using MunchBase.Consumers.Interfaces;
using MunchBase.Editors.Interfaces;
using MunchBase.Media.Entities;
using MunchBase.Media.Extensions;
using MunchBase.Media.ViewModels;
using MunchBase.Models.Interfaces;
using MunchBase.Producers.ViewModels;

namespace MunchBase.Media.Services;

public partial class MediaSetService
{

    public Task<PagedList<T>> GetMediaSets<T>(IAdmin admin, MediaSetQuery query, PagingQuery paging)
        where T : MediaSetDto
    {
        return GetMediaSets<T>(query, paging);
    }

    public Task<PagedList<T>> GetMediaSets<T>(IConsumer consumer, MediaSetQuery query, PagingQuery paging)
        where T : MediaSetDto
    {
        return GetMediaSets<T>(query, paging);
    }

    public Task<PagedList<T>> GetMediaSets<T>(IEditor editor, MediaSetQuery query, PagingQuery paging)
        where T : MediaSetDto
    {
        query.EditorId = editor.Id;
        return GetMediaSets<T>(query, paging);
    }

    public Task<PagedList<T>> GetMediaSets<T>(IProducer producer, MediaSetQuery query, PagingQuery paging)
        where T : MediaSetDto
    {
        query.ProducerId = producer.Id;
        return GetMediaSets<T>(query, paging);
    }

    public async Task<PagedList<T>> GetMediaSets<T>(IModel model, MediaSetQuery query, PagingQuery paging)
        where T : MediaSetDto
    {
        var sets = await GetMediaSets<T>(query, paging);

        foreach (var set in sets.Items)
        {
            set.Published = set.Published.Where(x => x.ModelId == model.Id).ToList();
            set.Models = set.Models.Where(x => x.Id == model.Id).ToList();
        }

        return sets;
    }

    private Task<PagedList<T>> GetMediaSets<T>(IQueryable<MediaSet> queryable, MediaSetQuery query, PagingQuery paging)
        where T : MediaSetDto
    {
        

        if (query.Models.Count > 0)
        {
            queryable = queryable.SelectMany(x => x.Models).Where(x => query.Models.Contains(x.ModelId))
                .Select(x => x.MediaSet);
        }

        if (query.Providers.Count > 0)
        {
            queryable = queryable.SelectMany(x => x.Providers).Where(x => query.Providers.Contains(x.ProviderId))
                .Select(x => x.MediaSet);
        }

        if (query.Channels.Count > 0)
        {
            queryable = queryable.SelectMany(x => x.Channels).Where(x => query.Channels.Contains(x.ChannelId))
                .Select(x => x.MediaSet);
        }


        return this.PaginateAsync<MediaSet, T>(queryable, query.GetExpression(), paging);
    }

    private Task<PagedList<T>> GetMediaSets<T>(MediaSetQuery query, PagingQuery paging)
        where T : MediaSetDto
    {
        var queryable = Repository.Queryable()
            .Include(x => x.Models)
            .Include(x => x.Providers)
            .ThenInclude(x => x.PublishedMediaSets)
            .Include(x => x.Channels)
            .AsQueryable();

        return GetMediaSets<T>(queryable, query, paging);
    }

}