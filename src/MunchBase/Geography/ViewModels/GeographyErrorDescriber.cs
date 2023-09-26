#region Header

// /*
// Copyright (c) 2021 SolutionStream. All rights reserved.
// Author: Rod Johnson, Architect, Munch
// */

#endregion

using MunchBase.Common.Models;

namespace MunchBase.Geography.ViewModels
{
    public class GeographyErrorDescriber
    {
        public virtual Error EnableCountryError()
        {
            return new()
            {
                Code = nameof(EnableCountryError),
                Description = "Unable to enable country"
            };
        }

        public virtual Error CountryAlreadyEnabled()
        {
            return new()
            {
                Code = nameof(CountryAlreadyEnabled),
                Description = "country already enabled"
            };
        }
    }
}