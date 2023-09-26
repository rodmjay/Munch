#region Header

// /*
// Copyright (c) 2021 SolutionStream. All rights reserved.
// Author: Rod Johnson, Architect, Munch
// */

#endregion

using MunchBase.Common.Queries;
using MunchBase.Geography.Entities;
using System;
using System.Linq.Expressions;
using MunchBase.Geography.ViewModels;

namespace MunchBase.Geography.Extensions
{
    public static class CountryQueryExtensions
    {
        public static Expression<Func<Country, bool>> GetExpression(this CountryQuery query)
        {
            var expr = PredicateBuilder.True<Country>();

            if (query.Enabled is true)
                expr = expr.And(x => x.EnabledCountry != null);

            if (query.Enabled is false)
                expr = expr.And(x => x.EnabledCountry == null);

            return expr;
        }
    }
}