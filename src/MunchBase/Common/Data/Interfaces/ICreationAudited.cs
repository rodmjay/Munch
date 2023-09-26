#region Header

// /*
// Copyright (c) 2021 Rod Johnson. All rights reserved.
// Author: Rod Johnson, Architect, Munch
// */

#endregion


namespace MunchBase.Common.Data.Interfaces
{
    public interface ICreationAudited : IHasCreationTime
    {
        /// <summary>Id of the creator user of this entity.</summary>
        long? CreatorUserId { get; set; }
    }
}