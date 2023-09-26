#region Header

// /*
// Copyright (c) 2021 SolutionStream. All rights reserved.
// Author: Rod Johnson, Architect, Munch
// */

#endregion


namespace MunchBase.Common.Data.Interfaces
{
    public interface IUserAudited :
        IAudited,
        IUserCreationAudited,
        IUserModificationAudited
    {
    }
}