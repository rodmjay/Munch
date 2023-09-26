#region Header

// /*
// Copyright (c) 2021 SolutionStream. All rights reserved.
// Author: Rod Johnson, Architect, Munch
// */

#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using MunchBase.Common.Data.Interfaces;
using MunchBase.Common.Extensions;
using MunchBase.Common.Models;
using MunchBase.Common.Services.Bases;
using MunchBase.Geography.Entities;
using MunchBase.Geography.Interfaces;
using MunchBase.Geography.ViewModels;

namespace MunchBase.Geography.Services
{
    public class CountryService : BaseService<Country>, ICountryService
    {
        private readonly IRepositoryAsync<StateProvince> _stateProvinceRepo;

        public CountryService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _stateProvinceRepo = UnitOfWork.RepositoryAsync<StateProvince>();
        }

        public IQueryable<Country> Countries => Repository.Queryable().Include(x => x.EnabledCountry);
        public IQueryable<StateProvince> StateProvinces => _stateProvinceRepo.Queryable();

        public Task<T> GetCountry<T>(string id) where T : CountryDto
        {
            return Countries.Where(x => x.Iso2 == id)
                .ProjectTo<T>(ProjectionMapping)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public Task<PagedList<T>> GetCountries<T>(Expression<Func<Country, bool>> predicate, PagingQuery paging)
            where T : CountryDto
        {
            return this.PaginateAsync<Country, T>(predicate, paging);
        }

        public Task<List<T>> GetStateProvincesForCountry<T>(string iso2) where T : StateProvinceDto
        {
            return StateProvinces.Where(x => x.Iso2 == iso2).ProjectTo<T>(ProjectionMapping)
                .AsNoTracking()
                .ToListAsync();
        }

        private string GetLogMessage(string message, [CallerMemberName] string callerName = null)
        {
            return $"[{nameof(CountryService)}.{callerName}] - {message}";
        }
    }
}