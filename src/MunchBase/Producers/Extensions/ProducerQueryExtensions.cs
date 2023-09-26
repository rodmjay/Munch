using System;
using System.Linq.Expressions;
using MunchBase.Common.Queries;
using MunchBase.Producers.Entities;
using MunchBase.Producers.ViewModels;

namespace MunchBase.Producers.Extensions;

public static class ProducerQueryExtensions
{
    public static Expression<Func<Producer, bool>> GetExpression(this ProducerQuery query)
    {
        var expr = PredicateBuilder.True<Producer>();

        return expr;
    }
}