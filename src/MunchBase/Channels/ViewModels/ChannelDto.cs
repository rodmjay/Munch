using System.Collections.Generic;
using MunchBase.Media.ViewModels;
using MunchBase.Producers.ViewModels;

namespace MunchBase.Channels.ViewModels
{
    public class ChannelDto
    {
        public string Name { get; set; }
        public List<MediaSetDto> MediaSets { get; set; }
        public List<ChannelProviderDto> Providers { get; set; }
        public List<ProducerDto> Producers { get; set; }
    }
}
