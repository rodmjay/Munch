using System.Threading.Tasks;
using MunchBase.Administration.Interfaces;
using MunchBase.Common.Extensions;
using MunchBase.Common.Models;
using MunchBase.Producers.Entities;
using MunchBase.Producers.Extensions;
using MunchBase.Producers.ViewModels;

namespace MunchBase.Producers.Services;

public partial class ProducerService
{
    public Task<PagedList<T>> GetProducers<T>(IAdmin admin, ProducerQuery query, PagingQuery paging)
    {
        return this.PaginateAsync<Producer, T>(query.GetExpression(), paging);
    }
}