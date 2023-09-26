using System.Linq;
using AutoMapper;
using MunchBase.Media.Entities;
using MunchBase.Media.ViewModels;
using MunchBase.Models.Entities;

namespace MunchBase.Media.Projections;

public class MediaSetProjections : Profile
{
    public MediaSetProjections()
    {
        CreateMap<MediaSet, MediaSetDto>()
            .ForMember(x => x.Caption, opt => opt.MapFrom(x => x.Caption))
            .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
            .ForMember(x => x.Providers, opt => opt.MapFrom(x => x.Providers))
            .ForMember(x => x.Channels, opt => opt.MapFrom(x => x.Channels))
            .ForMember(x => x.Producer, opt => opt.MapFrom(x => x.Producer))
            .ForMember(x => x.Editor, opt => opt.MapFrom(x => x.Editor))
            .ForMember(x => x.Models, opt => opt.MapFrom(x => x.Models))
            .ForMember(x => x.Media, opt => opt.MapFrom(x => x.Media))
            .ForMember(x=>x.Published, opt=>opt.MapFrom(x=>x.Providers.SelectMany(a=>a.PublishedMediaSets)))
            .IncludeAllDerived();

        CreateMap<ModelProviderMediaSet, MediaPublishedDto>()
            .ForMember(x => x.ModelId, opt => opt.MapFrom(x => x.ModelId))
            .ForMember(x => x.ProviderId, opt => opt.MapFrom(x => x.ProviderId));
        

        CreateMap<ModelMediaSet, MediaSetDto>()
            .ForMember(x => x.Caption, opt => opt.MapFrom(x => x.MediaSet.Caption))
            .ForMember(x => x.Id, opt => opt.MapFrom(x => x.MediaSet.Id))
            .ForMember(x => x.Providers, opt => opt.MapFrom(x => x.MediaSet.Providers))
            .ForMember(x => x.Channels, opt => opt.MapFrom(x => x.MediaSet.Channels))
            .ForMember(x => x.Producer, opt => opt.MapFrom(x => x.MediaSet.Producer))
            .ForMember(x => x.Editor, opt => opt.MapFrom(x => x.MediaSet.Editor))
            .ForMember(x => x.Models, opt => opt.MapFrom(x => x.MediaSet.Models))
            .ForMember(x => x.Media, opt => opt.MapFrom(x => x.MediaSet.Media))
            .IncludeAllDerived();

    }
}