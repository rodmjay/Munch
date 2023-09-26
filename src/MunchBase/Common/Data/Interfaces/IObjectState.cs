#region Header

// /*
// Copyright (c) 2021 Rod Johnson. All rights reserved.
// Author: Rod Johnson, Architect, Munch
// */

#endregion

using MunchBase.Common.Data.Enums;

namespace MunchBase.Common.Data.Interfaces
{
    public interface IObjectState
    {
        public ObjectState ObjectState { get; set; }
    }
}