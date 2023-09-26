#region Header

// /*
// Copyright (c) 2021 SolutionStream. All rights reserved.
// Author: Rod Johnson, Architect, Munch
// */

#endregion

using MunchBase.Geography.Interfaces;

namespace MunchBase.Geography.ViewModels
{
    public class CountryDto : ICountry
    {
        public string Name { get; set; }

        public string Iso2 { get; set; }

        public string CapsName { get; set; }

        public string Iso3 { get; set; }

        public int? NumberCode { get; set; }

        public int PhoneCode { get; set; }
    }
}