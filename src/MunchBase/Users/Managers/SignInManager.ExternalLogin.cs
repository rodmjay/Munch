#region Header

// /*
// Copyright (c) 2021 SolutionStream. All rights reserved.
// Author: Rod Johnson, Architect, Munch
// */

#endregion

using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MunchBase.Users.Managers
{
    public partial class SignInManager
    {
        public override Task<SignInResult> ExternalLoginSignInAsync(string loginProvider, string providerKey,
            bool isPersistent, bool bypassTwoFactor)
        {
            return base.ExternalLoginSignInAsync(loginProvider, providerKey, isPersistent, bypassTwoFactor);
        }

        public override Task<ExternalLoginInfo> GetExternalLoginInfoAsync(string expectedXsrf = null)
        {
            return base.GetExternalLoginInfoAsync(expectedXsrf);
        }

        public override Task<SignInResult> ExternalLoginSignInAsync(string loginProvider, string providerKey,
            bool isPersistent)
        {
            return base.ExternalLoginSignInAsync(loginProvider, providerKey, isPersistent);
        }
    }
}