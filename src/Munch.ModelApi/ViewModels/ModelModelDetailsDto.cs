using MunchBase.Media.ViewModels;
using MunchBase.Models.ViewModels;
using MunchBase.Tasks.ViewModels;

namespace Munch.ModelApi.ViewModels
{
    public class ModelModelDetailsDto : ModelDto
    {
        public List<TaskDto> Tasks { get; set; }
        public List<MediaSetDto> MediaSets { get; set; }
    }
}
