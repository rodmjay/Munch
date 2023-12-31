﻿#region Header

// /*
// Copyright (c) 2021 Rod Johnson. All rights reserved.
// Author: Rod Johnson, Architect, Munch
// */

#endregion

using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using MunchBase.Common.Services.Bases;
using MunchBase.Users.Entities;
using MunchBase.Users.Interfaces;
using MunchBase.Users.Managers;
using MunchBase.Users.ViewModels;

namespace MunchBase.Users.Services
{
    public class UserAccessor : BaseService<User>, IUserAccessor
    {
        private readonly UserManager _userManager;

        public UserAccessor(
            UserManager userManager,
            IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _userManager = userManager;
        }

        public Task<IUser> GetUser(ClaimsPrincipal principal)
        {
            var id = _userManager.GetUserId(principal);

            var userId = int.Parse(id);

            return _userManager.Users.Where(x => x.Id == userId)
                .ProjectTo<UserDto>(ProjectionMapping)
                .Cast<IUser>()
                .FirstOrDefaultAsync();
        }
    }
}