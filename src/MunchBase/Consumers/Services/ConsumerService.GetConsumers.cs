using System.Threading.Tasks;
using MunchBase.Administration.Interfaces;
using MunchBase.Common.Extensions;
using MunchBase.Common.Models;
using MunchBase.Consumers.Entities;
using MunchBase.Consumers.Extensions;
using MunchBase.Consumers.ViewModels;
using MunchBase.Models.Interfaces;

namespace MunchBase.Consumers.Services;

public partial class ConsumerService
{
    public Task<PagedList<T>> GetConsumers<T>(IModel model, ConsumerQuery query, PagingQuery paging)
        where T : ConsumerDto
    {
        return GetConsumers<T>(query, paging);
    }

    public Task<PagedList<T>> GetConsumers<T>(IAdmin admin, ConsumerQuery query, PagingQuery paging)
        where T : ConsumerDto
    {
        return GetConsumers<T>(query, paging);
    }

    private Task<PagedList<T>> GetConsumers<T>(ConsumerQuery query, PagingQuery paging)
        where T : ConsumerDto
    {
        return this.PaginateAsync<Consumer, T>(query.GetExpression(), paging);
    }

}