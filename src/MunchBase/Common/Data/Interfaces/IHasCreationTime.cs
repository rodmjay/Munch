#region Header

// /*
// Copyright (c) 2021 Rod Johnson. All rights reserved.
// Author: Rod Johnson, Architect, Munch
// */

#endregion

using System;

namespace MunchBase.Common.Data.Interfaces
{
    public interface IHasCreationTime
    {
        /// <summary>Creation time of this entity.</summary>
        DateTime Created { get; set; }
    }
}