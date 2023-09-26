using System;
using System.Linq.Expressions;
using MunchBase.Common.Queries;
using MunchBase.Media.Entities;
using MunchBase.Media.ViewModels;

namespace MunchBase.Media.Extensions;

public static class MediaSetQueryExtensions
{
    public static Expression<Func<MediaSet, bool>> GetExpression(this MediaSetQuery query)
    {
        var expr = PredicateBuilder.True<MediaSet>();
        
        if (query.EditorId != null)
            expr = expr.And(x => x.EditorId == query.EditorId.Value);

        if (query.ProducerId != null)
            expr = expr.And(x => x.ProducerId == query.ProducerId.Value);

        return expr;
    }
}