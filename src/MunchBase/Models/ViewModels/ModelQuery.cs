using System.Collections.Generic;

namespace MunchBase.Models.ViewModels;

public class ModelQuery
{
    public ModelQuery()
    {
        this.Models = new List<int>();
    }
    public List<int> Models { get; set; }
    public bool? ActiveOnly { get; set; }
}