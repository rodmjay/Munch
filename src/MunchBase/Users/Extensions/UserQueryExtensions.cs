using System;
using System.Linq.Expressions;
using MunchBase.Common.Queries;
using MunchBase.Users.Entities;
using MunchBase.Users.ViewModels;

namespace MunchBase.Users.Extensions;

public static class UserQueryExtensions
{
    public static Expression<Func<User, bool>> GetExpression(this UserQuery query)
    {
        var expr = PredicateBuilder.True<User>();

        //if (query.AssessmentId.HasValue)
        //    expr = expr.And(x => x.AssessmentId == topicQuery.AssessmentId.Value);

        return expr;
    }
}