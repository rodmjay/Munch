using System.Collections.Generic;
using MunchBase.Channels.ViewModels;
using MunchBase.Editors.ViewModels;
using MunchBase.Models.ViewModels;
using MunchBase.Producers.ViewModels;
using MunchBase.Providers.ViewModels;

namespace MunchBase.Media.ViewModels;

public class MediaSetDto
{

    public string Caption { get; set; }
    public int Id { get; set; }

    public List<ProviderDto> Providers { get; set; }
    public List<ChannelDto> Channels { get; set; }
    public List<ModelDto> Models { get; set; }
    public List<MediaDto> Media { get; set; }
    public List<MediaPublishedDto> Published { get; set; }

    public ProducerDto Producer { get; set; }
    public EditorDto Editor { get; set; }
}