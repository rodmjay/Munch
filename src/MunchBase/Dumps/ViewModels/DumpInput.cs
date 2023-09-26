using System.Collections.Generic;
using Microsoft.AspNetCore.Components.Forms;

namespace MunchBase.Dumps.ViewModels;

public class DumpInput
{
    public DumpInput()
    {
        ModelIds = new List<int>();
        Files = new List<InputFile>();
        Channels = new List<int>();
        Providers = new List<int>();
    }
    public string Name { get; set; }
    public string Instructions { get; set; }
    public List<int> ModelIds { get; set; }
    public List<int> Providers { get; set; }
    public List<InputFile> Files { get; set; }
    public int EditorId { get; set; }
    public List<int> Channels { get; set; }
}