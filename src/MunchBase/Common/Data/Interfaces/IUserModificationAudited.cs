#region Header

// /*
// Copyright (c) 2021 Rod Johnson. All rights reserved.
// Author: Rod Johnson, Architect, Munch
// */

#endregion

using MunchBase.Users.Entities;

namespace MunchBase.Common.Data.Interfaces
{
    public interface IUserModificationAudited : IModificationAudited
    {
        /// <summary>Reference to the last modifier user of this entity.</summary>
        User LastModifierUser { get; set; }
    }
}