using System.Collections.Generic;
using MunchBase.Channels.ViewModels;
using MunchBase.Editors.ViewModels;
using MunchBase.Producers.ViewModels;

namespace MunchBase.Dumps.ViewModels
{
    public class DumpDto
    {
        public string Name { get; set; }
        public string Instructions { get; set; }
        public int Id { get; set; }
        public List<ChannelDto> Channels { get; set; }
        public EditorDto Editor { get; set; }
        public ProducerDto Producer { get; set; }
    }
}
