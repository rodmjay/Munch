using AutoMapper;
using MunchBase.Channels.Entities;
using MunchBase.Producers.Entities;
using MunchBase.Producers.ViewModels;

namespace MunchBase.Producers.Projections
{
    public class ProducerProjections : Profile
    {
        public ProducerProjections()
        {
            CreateMap<Producer, ProducerDto>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.DisplayName, opt => opt.MapFrom(x => x.User.DisplayName));


            CreateMap<ChannelProducer, ProducerDto>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.ProducerId))
                .ForMember(x => x.DisplayName, opt => opt.MapFrom(x => x.Producer.User.FirstName));
        }
    }
}
