#region Header

// /*
// Copyright (c) 2021 SolutionStream. All rights reserved.
// Author: Rod Johnson, Architect, Munch
// */

#endregion

using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using MunchBase.Users.Entities;

namespace MunchBase.Users.Validators
{
    public class DuplicateUserNameValidator : IUserValidator<User>
    {
        private readonly IdentityErrorDescriber _errors;

        public DuplicateUserNameValidator(IdentityErrorDescriber errors)
        {
            _errors = errors;
        }

        public async Task<IdentityResult> ValidateAsync(UserManager<User> manager, User user)
        {
            var userByEmail = await manager.FindByEmailAsync(user.NormalizedEmail);
            if (userByEmail != null) return IdentityResult.Failed(_errors.DuplicateEmail(user.Email));
            return IdentityResult.Success;
        }
    }
}