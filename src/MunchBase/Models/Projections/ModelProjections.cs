using System.Linq;
using AutoMapper;
using MunchBase.Models.Entities;
using MunchBase.Models.ViewModels;

namespace MunchBase.Models.Projections
{
    public class ModelProjections : Profile
    {
        public ModelProjections()
        {
            CreateMap<Model, ModelDto>()
                .ForMember(x => x.DisplayName, opt => opt.MapFrom(x => x.User.DisplayName))
                .ForMember(x => x.Description, opt => opt.MapFrom(x => x.Description))
                .ForMember(x => x.MediaSetCount, opt => opt.MapFrom(x => x.MediaSets.Count))
                .IncludeAllDerived();

            CreateMap<ModelMediaSet, ModelDto>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.ModelId))
                .ForMember(x => x.DisplayName, opt => opt.MapFrom(x => x.Model.User.DisplayName))
                .IncludeAllDerived();

            CreateMap<Model, ModelDetailsDto>()
                .ForMember(x => x.Tasks, opt => opt.MapFrom(x => x.Tasks))
                .ForMember(x=>x.MediaSets, opt=>opt.MapFrom(x=>x.MediaSets));
        }
    }
}
