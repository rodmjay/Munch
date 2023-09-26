using System.Collections.Generic;

namespace MunchBase.Media.ViewModels;

public class MediaSetQuery
{
    public MediaSetQuery()
    {
        this.Models = new List<int>();
        this.Providers = new List<int>();
        this.Channels = new List<int>();
    }
    public int? ProducerId { get; set; }
    public List<int> Models { get; set; }
    public int? EditorId { get; set; }
    public List<int> Providers { get; set; }
    public List<int> Channels { get; set; }

}