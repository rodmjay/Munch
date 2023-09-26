#region Header

// /*
// Copyright (c) 2021 SolutionStream. All rights reserved.
// Author: Rod Johnson, Architect, Munch
// */

#endregion

using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MunchBase.Common.Data.Enums;
using MunchBase.Common.Models;
using MunchBase.Common.Services.Bases;
using MunchBase.Geography.Entities;
using MunchBase.Geography.Interfaces;
using MunchBase.Geography.ViewModels;

namespace MunchBase.Geography.Services
{
    public class EnabledCountryService : BaseService<EnabledCountry>, IEnabledCountryService
    {
        private readonly GeographyErrorDescriber _errors;

        public EnabledCountryService(
            GeographyErrorDescriber errors,
            IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _errors = errors;
        }

        public IQueryable<EnabledCountry> EnabledCountries => Repository.Queryable();

        public async Task<Result> EnableCountry(string iso2)
        {
            if (await EnabledCountries.Where(x => x.Iso2 == iso2).AnyAsync())
                return Result.Failed(_errors.CountryAlreadyEnabled());

            var enabledCountry = new EnabledCountry
            {
                Iso2 = iso2,
                ObjectState = ObjectState.Added
            };

            var changes = await Repository.InsertAsync(enabledCountry, true);
            if (changes < 1) return Result.Failed(_errors.EnableCountryError());

            return Result.Success(iso2);
        }
    }
}