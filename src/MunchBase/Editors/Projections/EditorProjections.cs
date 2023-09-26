using AutoMapper;
using MunchBase.Editors.Entities;
using MunchBase.Editors.ViewModels;

namespace MunchBase.Editors.Projections
{
    public class EditorProjections : Profile
    {
        public EditorProjections()
        {
            CreateMap<Editor, EditorDto>()
                .ForMember(x=>x.DisplayName, opt=>opt.MapFrom(x=>x.User.DisplayName));
        }
    }
}
