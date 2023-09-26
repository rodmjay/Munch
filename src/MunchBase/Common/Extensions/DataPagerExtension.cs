#region Header

// /*
// Copyright (c) 2021 Rod Johnson. All rights reserved.
// Author: Rod Johnson, Architect, Munch
// */

#endregion

using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using MunchBase.Common.Data.Interfaces;
using MunchBase.Common.Models;
using MunchBase.Common.Services.Interfaces;

namespace MunchBase.Common.Extensions
{
    public static class DataPagerExtension
    {
        public static async Task<PagedList<TOutput>> PaginateAsync<TEntity, TOutput>(
            this IService<TEntity> service,
            Expression<Func<TEntity, bool>> filter,
            PagingQuery paging)
            where TEntity : class, IObjectState
        {
            return await PaginateAsync<TEntity, TOutput>(service, service.Repository.Queryable(),
                filter, paging);
        }


        public static async Task<PagedList<TOutput>> PaginateAsync<TEntity, TOutput>(
            this IService<TEntity> service, 
            IQueryable<TEntity> queryable,
            Expression<Func<TEntity, bool>> filter,
            PagingQuery paging)
            where TEntity : class, IObjectState
        {
            var paged = new PagedList<TOutput>();

            paging.Page = paging.Page <= 0 ? 1 : paging.Page;
            paging.Size = paging.Size > 0 ? paging.Size : 10;

            paged.CurrentPage = paging.Page;
            paged.PageSize = paging.Size;

            var totalCount = await queryable
                .Where(filter)
                .CountAsync();

            var startRow = (paging.Page - 1) * paging.Size;

            paged.Items = await queryable
                .Where(filter)
                .OrderBy(paging.Sort)
                .ProjectTo<TOutput>(service.ProjectionMapping)
                .Skip(startRow)
                .Take(paging.Size)
                .ToListAsync();


            paged.TotalItems = totalCount;
            paged.TotalPages = (int)Math.Ceiling(paged.TotalItems / (double)paging.Size);

            return paged;
        }
    }
}