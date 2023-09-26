using AutoMapper;
using MunchBase.Administration.Entities;
using MunchBase.Administration.ViewModels;

namespace MunchBase.Administration.Projections
{
    public class AdminProjections : Profile
    {
        public AdminProjections()
        {
            CreateMap<Admin, AdminDto>()
                .ForMember(x => x.FirstName, opt => opt.MapFrom(x => x.User.FirstName))
                .ForMember(x => x.LastName, opt => opt.MapFrom(x => x.User.LastName))
                .IncludeAllDerived();
        }
    }
}
