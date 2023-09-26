#region Header

// /*
// Copyright (c) 2021 SolutionStream. All rights reserved.
// Author: Rod Johnson, Architect, Munch
// */

#endregion

using MunchBase.Common.Models;
using MunchBase.Geography.Entities;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MunchBase.Geography.ViewModels;

namespace MunchBase.Geography.Interfaces
{
    public interface ICountryStore
    {
        Task<T> GetCountry<T>(string iso2) where T : CountryDto;

        Task<PagedList<T>> GetCountries<T>(Expression<Func<Country, bool>> predicate, PagingQuery paging)
            where T : CountryDto;
    }
}