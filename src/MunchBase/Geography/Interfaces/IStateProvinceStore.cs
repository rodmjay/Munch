#region Header

// /*
// Copyright (c) 2021 SolutionStream. All rights reserved.
// Author: Rod Johnson, Architect, Munch
// */

#endregion

using System.Collections.Generic;
using System.Threading.Tasks;
using MunchBase.Geography.ViewModels;

namespace MunchBase.Geography.Interfaces
{
    public interface IStateProvinceStore
    {
        Task<List<T>> GetStateProvincesForCountry<T>(string id) where T : StateProvinceDto;
    }
}