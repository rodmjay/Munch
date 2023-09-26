using System.Threading.Tasks;
using MunchBase.Administration.Interfaces;
using MunchBase.Common.Extensions;
using MunchBase.Common.Models;
using MunchBase.Consumers.Interfaces;
using MunchBase.Editors.Interfaces;
using MunchBase.Models.Entities;
using MunchBase.Models.Extensions;
using MunchBase.Models.Interfaces;
using MunchBase.Models.ViewModels;
using MunchBase.Producers.ViewModels;

namespace MunchBase.Models.Services;

public partial class ModelService
{
    public Task<PagedList<T>> GetModels<T>(IAdmin admin, PagingQuery paging, ModelQuery query)
        where T : ModelDto
    {

        return GetModels<T>(paging, query);
    }

    public Task<PagedList<T>> GetModels<T>(IEditor editor, PagingQuery paging, ModelQuery query)
        where T : ModelDto
    {
        return GetModels<T>(paging, query);
    }

    public Task<PagedList<T>> GetModels<T>(IProducer producer, PagingQuery paging, ModelQuery query)
        where T : ModelDto
    {
        return GetModels<T>(paging, query);
    }

    public Task<PagedList<T>> GetModels<T>(IModel model, PagingQuery paging, ModelQuery query)
        where T : ModelDto
    {
        return GetModels<T>(paging, query);
    }

    public Task<PagedList<T>> GetModels<T>(IConsumer consumer, PagingQuery paging, ModelQuery query)
        where T : ModelDto
    {
        return GetModels<T>(paging, query);
    }

    private Task<PagedList<T>> GetModels<T>(PagingQuery paging, ModelQuery query)
        where T : ModelDto
    {
        var expr = query.GetExpression();
        
        return this.PaginateAsync<Model, T>(expr, paging);
    }
}