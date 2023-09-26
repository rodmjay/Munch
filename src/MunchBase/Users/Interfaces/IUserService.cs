#region Header

// /*
// Copyright (c) 2021 SolutionStream. All rights reserved.
// Author: Rod Johnson, Architect, Munch
// */

#endregion

using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using MunchBase.Administration.Interfaces;
using MunchBase.Common.Models;
using MunchBase.Common.Services.Interfaces;
using MunchBase.Users.Entities;
using MunchBase.Users.ViewModels;

namespace MunchBase.Users.Interfaces
{
    public interface IUserService : IService<User>,
        IQueryableUserStore<User>,
        IUserPasswordStore<User>,
        IUserClaimStore<User>,
        IUserLoginStore<User>,
        IUserLockoutStore<User>,
        IUserPhoneNumberStore<User>,
        IUserEmailStore<User>,
        IUserAuthenticatorKeyStore<User>,
        IUserTwoFactorStore<User>,
        IUserTwoFactorRecoveryCodeStore<User>,
        IUserSecurityStampStore<User>,
        IUserAuthenticationTokenStore<User>
    {
        Task<PagedList<T>> GetUsers<T>(IAdmin admin, Expression<Func<User, bool>> expr, PagingQuery paging) where T : UserDto;
        Task<T> GetUser<T>(IAdmin admin, int userId) where T : UserDto;
        Task<Result> CreateUser(IAdmin admin, UserInput input);
        Task<IdentityResult> CreateUser(UserInput input); 
    }
}