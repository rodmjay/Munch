#region Header

// /*
// Copyright (c) 2021 Rod Johnson. All rights reserved.
// Author: Rod Johnson, Architect, Munch
// */

#endregion

using MunchBase.Geography.Interfaces;

namespace MunchBase.Geography.ViewModels
{
    public class StateProvinceDto : IStateProvince
    {
        public string Name { get; set; }

        public string Abbrev { get; set; }

        public string Code { get; set; }
    }
}