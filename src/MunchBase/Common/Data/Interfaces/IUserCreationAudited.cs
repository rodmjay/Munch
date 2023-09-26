#region Header

// /*
// Copyright (c) 2021 SolutionStream. All rights reserved.
// Author: Rod Johnson, Architect, Munch
// */

#endregion

using MunchBase.Users.Entities;

namespace MunchBase.Common.Data.Interfaces
{
    public interface IUserCreationAudited : ICreationAudited, IHasCreationTime
    {
        /// <summary>Reference to the creator user of this entity.</summary>
        User CreatorUser { get; set; }
    }
}