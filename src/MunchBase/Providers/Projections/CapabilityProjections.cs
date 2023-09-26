using AutoMapper;
using MunchBase.Providers.Entities;
using MunchBase.Providers.ViewModels;

namespace MunchBase.Providers.Projections;

public class CapabilityProjections : Profile
{
    public CapabilityProjections()
    {
        CreateMap<Capability, CapabilityDto>()
            .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name));

        CreateMap<ProviderCapability, CapabilityDto>()
            .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Capability.Name));
    }
}