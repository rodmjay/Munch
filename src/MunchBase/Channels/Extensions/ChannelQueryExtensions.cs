using System;
using System.Linq.Expressions;
using MunchBase.Channels.Entities;
using MunchBase.Channels.ViewModels;
using MunchBase.Common.Queries;

namespace MunchBase.Channels.Extensions;

public static class ChannelQueryExtensions
{
    public static Expression<Func<Channel, bool>> GetExpression(this ChannelQuery query)
    {
        var expr = PredicateBuilder.True<Channel>();

        return expr;
    }
}