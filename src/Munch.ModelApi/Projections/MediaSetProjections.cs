using AutoMapper;
using Munch.ModelApi.ViewModels;
using MunchBase.Models.Entities;

namespace Munch.ModelApi.Projections;

public class MediaSetProjections : Profile
{
    public MediaSetProjections()
    {
        CreateMap<ModelMediaSet, ModelMediaSetDto>()
            .ForMember(x=>x.Published, opt=>opt.MapFrom(x=>x.PublishedMediaSets.Any()));
    }
}