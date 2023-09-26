using System.Collections.Generic;

namespace MunchBase.Media.ViewModels;

public class MediaSetInput
{
    public MediaSetInput()
    {
        Media = new List<MediaInput>();
        Providers = new List<int>();
        Models = new List<int>();
        Channels = new List<int>();
    }
    public int? DumpId { get; set; }
    public int? ProducerId { get; set; }
    public string Comments { get; set; }
    public string Caption { get; set; }
    public List<MediaInput> Media { get; set; }
    public List<int> Providers { get; set; }
    public List<int> Models { get; set; }
    public List<int> Channels { get; set; }
}