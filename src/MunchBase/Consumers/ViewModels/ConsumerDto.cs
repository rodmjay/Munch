using MunchBase.Consumers.Interfaces;

namespace MunchBase.Consumers.ViewModels
{
    public class ConsumerDto : IConsumer
    {
        public bool Active { get; set; }
        public int Id { get; set; }
        public string DisplayName { get; set; }
    }
}
