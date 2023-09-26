using System.Collections.Generic;
using MunchBase.Media.ViewModels;
using MunchBase.Tasks.ViewModels;

namespace MunchBase.Models.ViewModels;

public class ModelDetailsDto : ModelDto
{
    public List<TaskDto> Tasks { get; set; }
    public List<MediaSetDto> MediaSets { get; set; }
}