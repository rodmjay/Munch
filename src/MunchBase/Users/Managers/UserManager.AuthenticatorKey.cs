﻿#region Header

// /*
// Copyright (c) 2021 Rod Johnson. All rights reserved.
// Author: Rod Johnson, Architect, Munch
// */

#endregion

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using MunchBase.Users.Entities;

namespace MunchBase.Users.Managers
{
    public partial class UserManager
    {
        public override async Task<IdentityResult> ResetAuthenticatorKeyAsync(User user)
        {
            ThrowIfDisposed();
            if (user == null) throw new ArgumentNullException(nameof(user));
            await _userService.SetAuthenticatorKeyAsync(user, GenerateNewAuthenticatorKey(), CancellationToken);
            await UpdateSecurityStampInternal(user);
            return await UpdateAsync(user);
        }

        public override string GenerateNewAuthenticatorKey()
        {
            return NewSecurityStamp();
        }

        public override Task<string> GetAuthenticatorKeyAsync(User user)
        {
            ThrowIfDisposed();
            if (user == null) throw new ArgumentNullException(nameof(user));
            return _userService.GetAuthenticatorKeyAsync(user, CancellationToken);
        }
    }
}