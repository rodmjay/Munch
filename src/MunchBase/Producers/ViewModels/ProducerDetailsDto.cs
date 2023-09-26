using MunchBase.Models.ViewModels;

namespace MunchBase.Producers.ViewModels;

public class ProducerDetailsDto : ProducerDto
{
    public ModelDto[] Models { get; set; }
}