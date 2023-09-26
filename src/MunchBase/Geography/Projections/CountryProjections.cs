#region Header

// /*
// Copyright (c) 2021 Rod Johnson. All rights reserved.
// Author: Rod Johnson, Architect, Munch
// */

#endregion

using AutoMapper;
using MunchBase.Common.Models;
using MunchBase.Geography.Entities;
using MunchBase.Geography.ViewModels;

namespace MunchBase.Geography.Projections
{
    public class CountryProjections : Profile
    {
        public CountryProjections()
        {
            CreateMap<Country, CountryDto>()
                .IncludeAllDerived();

            CreateMap<Country, CountryWithStateProvinces>()
                .ForMember(x => x.StateProvinces, opt => opt.MapFrom(x => x.StateProvinces))
                .IncludeAllDerived();

            CreateMap<Country, DropdownItem>()
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
                .ForMember(x => x.Value, opt => opt.MapFrom(x => x.Iso2));
        }
    }
}