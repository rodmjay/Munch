#region Header

// /*
// Copyright (c) 2021 SolutionStream. All rights reserved.
// Author: Rod Johnson, Architect, Munch
// */

#endregion

using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using MunchBase.Users.Entities;
using MunchBase.Users.Managers;

namespace MunchBase.Users.Factories
{
    public class UserRoleClaimsPrincipalFactory : UserClaimsPrincipalFactory
    {
        private readonly UserManager _userManager;

        public UserRoleClaimsPrincipalFactory(UserManager userManager,
            IOptions<IdentityOptions> optionsAccessor) : base(userManager, optionsAccessor)
        {
            _userManager = userManager;
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(User user)
        {
            var id = await base.GenerateClaimsAsync(user);

            return id;
        }
    }
}