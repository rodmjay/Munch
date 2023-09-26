#region Header

// /*
// Copyright (c) 2021 SolutionStream. All rights reserved.
// Author: Rod Johnson, Architect, Munch
// */

#endregion


namespace MunchBase.Geography.Interfaces
{
    public interface IStateProvince
    {
        string Name { get; set; }
        string Abbrev { get; set; }
        string Code { get; set; }
    }
}