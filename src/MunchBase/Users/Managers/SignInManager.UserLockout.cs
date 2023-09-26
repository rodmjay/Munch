#region Header

// /*
// Copyright (c) 2021 SolutionStream. All rights reserved.
// Author: Rod Johnson, Architect, Munch
// */

#endregion

using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using MunchBase.Users.Entities;

namespace MunchBase.Users.Managers
{
    public partial class SignInManager
    {
        protected override Task<SignInResult> LockedOut(User user)
        {
            Logger.LogWarning(3, "User is currently locked out.");
            return Task.FromResult(SignInResult.LockedOut);
        }

        protected override async Task<bool> IsLockedOut(User user)
        {
            return UserManager.SupportsUserLockout && await UserManager.IsLockedOutAsync(user);
        }
    }
}