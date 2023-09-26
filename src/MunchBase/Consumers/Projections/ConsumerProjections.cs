using AutoMapper;
using MunchBase.Consumers.Entities;
using MunchBase.Consumers.ViewModels;

namespace MunchBase.Consumers.Projections
{
    internal class ConsumerProjections : Profile
    {
        public ConsumerProjections()
        {
            CreateMap<Consumer, ConsumerDto>()
                .ForMember(x => x.DisplayName, opt => opt.MapFrom(x => x.User.DisplayName));
                ;
        }
    }
}
