using System.Collections.Generic;

namespace MunchBase.Providers.ViewModels
{
    public class ProviderDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<CapabilityDto> Capabilities { get; set; }
    }
}
