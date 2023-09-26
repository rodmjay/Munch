using System;
using System.Linq.Expressions;
using MunchBase.Common.Queries;
using MunchBase.Editors.Entities;
using MunchBase.Editors.ViewModels;

namespace MunchBase.Editors.Extensions;

public static class EditorQueryExtensions
{
    public static Expression<Func<Editor, bool>> GetExpression(this EditorQuery query)
    {
        var expr = PredicateBuilder.True<Editor>();
        return expr;
    }
}