#region Header

// /*
// Copyright (c) 2021 SolutionStream. All rights reserved.
// Author: Rod Johnson, Architect, Munch
// */

#endregion

using MunchBase.Common.Models;
using MunchBase.Common.Services.Interfaces;
using MunchBase.Geography.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace MunchBase.Geography.Interfaces
{
    public interface IEnabledCountryService : IService<EnabledCountry>
    {
        IQueryable<EnabledCountry> EnabledCountries { get; }

        Task<Result> EnableCountry(string iso2);
    }
}