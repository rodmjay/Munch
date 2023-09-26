#region Header

// /*
// Copyright (c) 2021 SolutionStream. All rights reserved.
// Author: Rod Johnson, Architect, Munch
// */

#endregion

using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using MunchBase.Common;

namespace MunchBase.Users.Managers
{
    public partial class SignInManager
    {
        public override async Task SignOutAsync()
        {
            await Context.SignOutAsync(Constants.LocalIdentity.DefaultApplicationScheme);
            await Context.SignOutAsync(Constants.LocalIdentity.DefaultExternalScheme);
            await Context.SignOutAsync(IdentityConstants.TwoFactorUserIdScheme);
        }
    }
}