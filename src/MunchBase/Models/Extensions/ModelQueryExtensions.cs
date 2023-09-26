using System;
using System.Linq.Expressions;
using MunchBase.Common.Queries;
using MunchBase.Models.Entities;
using MunchBase.Models.ViewModels;

namespace MunchBase.Models.Extensions;

public static class ModelQueryExtensions
{
    public static Expression<Func<Model, bool>> GetExpression(this ModelQuery query)
    {
        var expr = PredicateBuilder.True<Model>();

        if (query.Models.Count > 0)
            expr = expr.And(x => query.Models.Contains(x.Id));
        
        return expr;
    }
}