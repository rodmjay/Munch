using AutoMapper;
using MunchBase.Tasks.ViewModels;

namespace MunchBase.Tasks.Projections
{
    public class TaskProjections : Profile
    {
        public TaskProjections()
        {
            CreateMap<Entities.Task, TaskDto>();
        }
    }
}
