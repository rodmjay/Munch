using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MunchBase.Administration.Interfaces;
using MunchBase.Common.Extensions;
using MunchBase.Common.Models;
using MunchBase.Dumps.Entities;
using MunchBase.Dumps.Extensions;
using MunchBase.Dumps.ViewModels;
using MunchBase.Editors.Interfaces;
using MunchBase.Producers.ViewModels;

namespace MunchBase.Dumps.Services;

public partial class DumpService
{
    public Task<PagedList<T>> GetDumps<T>(IEditor editor, PagingQuery paging, DumpQuery query)
        where T : DumpDto
    {
        var expr = query.GetExpression();
        return GetDumps<T>(paging, expr);
    }

    public Task<PagedList<T>> GetDumps<T>(IProducer producer, PagingQuery paging, DumpQuery query)
        where T : DumpDto
    {
        var expr = query.GetExpression();
        return GetDumps<T>(paging, expr);
    }

    public Task<PagedList<T>> GetDumps<T>(IAdmin admin, PagingQuery paging, DumpQuery query)
        where T : DumpDto
    {
        var expr = query.GetExpression();
        return GetDumps<T>(paging, expr);
    }

    private Task<PagedList<T>> GetDumps<T>(PagingQuery paging, Expression<Func<Dump, bool>> expr)
        where T : DumpDto
    {
        return this.PaginateAsync<Dump, T>(expr, paging);
    }
}