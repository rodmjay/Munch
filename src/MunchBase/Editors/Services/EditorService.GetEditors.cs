using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MunchBase.Administration.Interfaces;
using MunchBase.Common.Extensions;
using MunchBase.Common.Models;
using MunchBase.Editors.Entities;
using MunchBase.Editors.Extensions;
using MunchBase.Editors.ViewModels;
using MunchBase.Models.Interfaces;
using MunchBase.Producers.ViewModels;

namespace MunchBase.Editors.Services;

public partial class EditorService
{
    public Task<PagedList<T>> GetEditors<T>(IAdmin admin, EditorQuery query, PagingQuery paging)
        where T : EditorDto
    {
        return GetEditors<T>(query.GetExpression(), paging);
    }

    public Task<PagedList<T>> GetEditors<T>(IProducer producers, EditorQuery query,
        PagingQuery paging) where T : EditorDto
    {
        return GetEditors<T>(query.GetExpression(), paging);
    }

    public Task<PagedList<T>> GetEditors<T>(IModel model, EditorQuery query, PagingQuery paging)
        where T : EditorDto
    {
        return GetEditors<T>(query.GetExpression(), paging);
    }

    private Task<PagedList<T>> GetEditors<T>(Expression<Func<Editor, bool>> expr, PagingQuery paging)
        where T : EditorDto
    {
        return this.PaginateAsync<Editor, T>(expr, paging);
    }
}