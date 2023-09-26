#region Header

// /*
// Copyright (c) 2021 Rod Johnson. All rights reserved.
// Author: Rod Johnson, Architect, Munch
// */

#endregion

using System.Security.Claims;
using System.Threading.Tasks;

namespace MunchBase.Users.Interfaces
{
    public interface IUserAccessor
    {
        Task<IUser> GetUser(ClaimsPrincipal principal);
    }
}