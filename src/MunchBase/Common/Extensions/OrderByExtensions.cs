﻿#region Header

// /*
// Copyright (c) 2021 SolutionStream. All rights reserved.
// Author: Rod Johnson, Architect, Munch
// */

#endregion

using MunchBase.Common.Models;
using System.Linq;

namespace MunchBase.Common.Extensions
{
    public static class OrderByExtensions
    {
        public static IQueryable<TSource> OrderBy<TSource>(
            this IQueryable<TSource> queryable,
            string sorts)
        {
            if (string.IsNullOrWhiteSpace(sorts))
                return queryable;

            var sort = new SortCollection<TSource>(sorts);
            return sort.Apply(queryable);
        }

        public static IQueryable<TSource> OrderBy<TSource>(
            this IQueryable<TSource> queryable,
            params string[] sorts)
        {
            var sort = new SortCollection<TSource>(sorts);
            return sort.Apply(queryable);
        }

        public static IQueryable<TSource> OrderBy<TSource>(
            this IQueryable<TSource> queryable,
            string sorts,
            out SortCollection<TSource> sortCollection)
        {
            sortCollection = new SortCollection<TSource>(sorts);
            return sortCollection.Apply(queryable);
        }
    }
}