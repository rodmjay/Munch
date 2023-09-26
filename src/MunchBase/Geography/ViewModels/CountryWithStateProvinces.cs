#region Header

// /*
// Copyright (c) 2021 SolutionStream. All rights reserved.
// Author: Rod Johnson, Architect, Munch
// */

#endregion

using System.Collections.Generic;

namespace MunchBase.Geography.ViewModels
{
    public class CountryWithStateProvinces : CountryDto
    {
        public CountryWithStateProvinces()
        {
            StateProvinces = new List<StateProvinceDto>();
        }

        public List<StateProvinceDto> StateProvinces { get; set; }
    }
}