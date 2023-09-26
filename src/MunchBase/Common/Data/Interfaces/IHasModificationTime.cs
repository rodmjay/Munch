#region Header

// /*
// Copyright (c) 2021 Rod Johnson. All rights reserved.
// Author: Rod Johnson, Architect, Munch
// */

#endregion

using System;

namespace MunchBase.Common.Data.Interfaces
{
    public interface IHasModificationTime
    {
        /// <summary>The last modified time for this entity.</summary>
        DateTime? Updated { get; set; }
    }
}