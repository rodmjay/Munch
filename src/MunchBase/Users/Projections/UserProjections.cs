#region Header

// /*
// Copyright (c) 2021 Rod Johnson. All rights reserved.
// Author: Rod Johnson, Architect, Munch
// */

#endregion

using AutoMapper;
using MunchBase.Users.Entities;
using MunchBase.Users.ViewModels;

namespace MunchBase.Users.Projections
{
    public class UserProjections : Profile
    {
        public UserProjections()
        {
            CreateMap<User, UserDto>()
                .ForMember(x => x.IsAdmin, opt => opt.MapFrom(x => x.Admin != null))
                .ForMember(x => x.IsProducer, opt => opt.MapFrom(x => x.Producer != null))
                .ForMember(x => x.IsModel, opt => opt.MapFrom(x => x.Model != null))
                .ForMember(x => x.IsEditor, opt => opt.MapFrom(x => x.Editor != null))
                .ForMember(x => x.IsConsumer, opt => opt.MapFrom(x => x.Consumer != null))
                .IncludeAllDerived();
        }
    }
}