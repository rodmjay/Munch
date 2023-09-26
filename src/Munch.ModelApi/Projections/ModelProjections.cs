using AutoMapper;
using Munch.ModelApi.ViewModels;
using MunchBase.Media.Entities;
using MunchBase.Models.Entities;

namespace Munch.ModelApi.Projections
{
    public class ModelProjections : Profile
    {
        public ModelProjections()
        {


            CreateMap<Model, ModelModelDetailsDto>()
                .ForMember(x => x.MediaSets, opt => opt.MapFrom(x => x.MediaSets))
                .ForMember(x => x.Tasks, opt => opt.MapFrom(x => x.Tasks));
        }
    }
}
