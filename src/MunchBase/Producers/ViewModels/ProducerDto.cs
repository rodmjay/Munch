namespace MunchBase.Producers.ViewModels
{
    public class ProducerDto : IProducer
    {
        public bool Active { get; set; }

        public int Id { get; set; }
        public string DisplayName { get; set; }
    }
}
