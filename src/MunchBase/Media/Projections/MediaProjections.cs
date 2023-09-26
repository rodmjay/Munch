using AutoMapper;
using MunchBase.Media.Entities;
using MunchBase.Media.ViewModels;

namespace MunchBase.Media.Projections
{
    public class MediaProjections : Profile
    {
        public MediaProjections()
        {
            CreateMap<Entities.Media, MediaDto>()
                .ForMember(x => x.Video, opt => opt.MapFrom(x => x.Video))
                .ForMember(x => x.Photo, opt => opt.MapFrom(x => x.Photo))
                .ForMember(x => x.IsApproved, opt => opt.MapFrom(x => x.Approval != null && x.Approval.IsApproved))
                .ForMember(x => x.IsExplicit, opt => opt.MapFrom(x => x.IsExplicit))
                .ForMember(x => x.IsDraft, opt => opt.MapFrom(x => x.IsDraft))
                .IncludeAllDerived();

            CreateMap<Video, VideoDto>();
            CreateMap<Photo, PhotoDto>();
        }
    }
}
