using AutoMapper;
using MunchBase.Dumps.Entities;
using MunchBase.Dumps.ViewModels;

namespace MunchBase.Dumps.Projections
{
    internal class DumpProjections : Profile
    {
        public DumpProjections()
        {
            CreateMap<Dump, DumpDto>()
                .ForMember(x => x.Instructions, opt => opt.MapFrom(x => x.Instructions))
                .ForMember(x => x.Producer, opt => opt.MapFrom(x => x.Producer))
                .ForMember(x => x.Editor, opt => opt.MapFrom(x => x.Editor))
                .ForMember(x => x.Channels, opt => opt.MapFrom(x => x.ChannelIntents));
        }
    }
}
