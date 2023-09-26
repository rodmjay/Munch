using System.Linq;
using AutoMapper;
using MunchBase.Media.Entities;
using MunchBase.Providers.Entities;
using MunchBase.Providers.ViewModels;

namespace MunchBase.Providers.Projections
{
    public class ProviderProjections : Profile
    {
        public ProviderProjections()
        {
            CreateMap<Provider, ProviderDto>()
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.Capabilities, opt => opt.MapFrom(x => x.ProviderCapabilities))
                .IncludeAllDerived();

            CreateMap<MediaSetProvider, ProviderDto>()
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Provider.Name))
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Provider.Id))
                .IncludeAllDerived();

            CreateMap<Provider, ModelProviderDto>()
                .ForMember(x=>x.Username, opt=>opt.MapFrom(x=>x.ModelProviders.FirstOrDefault().Username))
                .ForMember(x => x.Enabled, opt => opt.MapFrom(x => x.ModelProviders != null && x.ModelProviders.Count > 0));
        }
    }
}
