using System;
using System.Linq.Expressions;
using MunchBase.Common.Queries;
using MunchBase.Consumers.Entities;
using MunchBase.Consumers.ViewModels;

namespace MunchBase.Consumers.Extensions
{
    public static class ConsumerQueryExtensions
    {
        public static Expression<Func<Consumer, bool>> GetExpression(this ConsumerQuery query)
        {
            var expr = PredicateBuilder.True<Consumer>();

            return expr;
        }
    }
}
