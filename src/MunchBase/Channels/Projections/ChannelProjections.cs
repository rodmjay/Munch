using AutoMapper;
using MunchBase.Channels.Entities;
using MunchBase.Channels.ViewModels;
using MunchBase.Media.ViewModels;

namespace MunchBase.Channels.Projections
{
    public class ChannelProjections : Profile
    {
        public ChannelProjections()
        {
            CreateMap<Channel, ChannelDto>()
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
                .ForMember(x => x.MediaSets, opt => opt.MapFrom(x => x.MediaSets))
                .ForMember(x => x.Providers, opt => opt.MapFrom(x => x.Providers))
                .ForMember(x=>x.Producers, opt=>opt.MapFrom(x=>x.Producers))
                .IncludeAllDerived();

            CreateMap<ChannelMediaSet, ChannelDto>()
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Channel.Name))
                .IncludeAllDerived();

            CreateMap<ChannelMediaSet, MediaSetDto>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.MediaSetId))
                .ForMember(x => x.Caption, opt => opt.MapFrom(x => x.MediaSet.Caption))
                .IncludeAllDerived();

            CreateMap<ChannelIntent, ChannelDto>()
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Channel.Name));

            CreateMap<ChannelProvider, ChannelProviderDto>()
                .ForMember(x => x.ProviderId, opt => opt.MapFrom(x => x.Provider.Id))
                .ForMember(x => x.ProviderName, opt => opt.MapFrom(x => x.Provider.Name))
                .ForMember(x => x.Identifier, opt => opt.MapFrom(x => x.Identifier));

        }


    }
}
