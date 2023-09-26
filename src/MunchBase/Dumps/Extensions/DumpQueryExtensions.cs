using System;
using System.Linq.Expressions;
using MunchBase.Common.Queries;
using MunchBase.Dumps.Entities;
using MunchBase.Dumps.ViewModels;

namespace MunchBase.Dumps.Extensions;

public static class DumpQueryExtensions
{
    public static Expression<Func<Dump, bool>> GetExpression(this DumpQuery query)
    {
        var expr = PredicateBuilder.True<Dump>();

        if (query.EditorId.HasValue)
            expr.And(x => x.EditorId == query.EditorId.Value);

        if (query.ProducerId.HasValue)
            expr.And(x => x.ProducerId == query.ProducerId.Value);
        return expr;
    }
}