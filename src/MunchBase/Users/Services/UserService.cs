#region Header

// /*
// Copyright (c) 2021 SolutionStream. All rights reserved.
// Author: Rod Johnson, Architect, Munch
// */

#endregion

using System;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MunchBase.Administration.Interfaces;
using MunchBase.Common.Data.Enums;
using MunchBase.Common.Data.Interfaces;
using MunchBase.Common.Extensions;
using MunchBase.Common.Models;
using MunchBase.Common.Services.Bases;
using MunchBase.Consumers.Entities;
using MunchBase.Editors.Entities;
using MunchBase.Models.Entities;
using MunchBase.Producers.Entities;
using MunchBase.Users.Entities;
using MunchBase.Users.Interfaces;
using MunchBase.Users.ViewModels;

namespace MunchBase.Users.Services
{
    public partial class UserService : BaseService<User>, IUserService
    {
        private const string InternalLoginProvider = "[AspNetUserStore]";
        private const string AuthenticatorKeyTokenName = "AuthenticatorKey";
        private const string RecoveryCodeTokenName = "RecoveryCodes";
        private readonly IdentityErrorDescriber _errors;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IRepositoryAsync<UserClaim> _userClaimsRepository;
        private readonly IRepositoryAsync<UserLogin> _userLoginRepository;

        private readonly IRepositoryAsync<UserToken> _userTokenRepository;
        private bool _disposed;

        public UserService(
            IdentityErrorDescriber errors,
            IPasswordHasher<User> passwordHasher,
            IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _userTokenRepository = UnitOfWork.RepositoryAsync<UserToken>();

            _userClaimsRepository = UnitOfWork.RepositoryAsync<UserClaim>();
            _userLoginRepository = UnitOfWork.RepositoryAsync<UserLogin>();

            _errors = errors;
            _passwordHasher = passwordHasher;
        }


        public void Dispose()
        {
            UnitOfWork.Dispose();
            _disposed = true;
        }

        public Task<PagedList<T>> GetUsers<T>(IAdmin admin, Expression<Func<User, bool>> expr, PagingQuery paging) where T : UserDto
        {
            return this.PaginateAsync<User, T>(expr, paging);
        }

        public Task<T> GetUser<T>(IAdmin admin, int userId) where T : UserDto
        {
            return Users.Where(x => x.Id == userId).ProjectTo<T>(ProjectionMapping).FirstAsync();
        }

        public Task<Result> CreateUser(IAdmin admin, UserInput input)
        {
            throw new NotImplementedException();
        }

        public async Task<IdentityResult> CreateUser(UserInput input)
        {
            var user = new User()
            {
                DisplayName = input.Displayname,
                UserName = input.Username,
                FirstName = input.FirstName,
                LastName = input.LastName,
                Email = input.Email,
                Code3 = input.Code3,
                Iso2 = input.Iso2,
                ObjectState = ObjectState.Added
            };

            if (input.IsModel)
            {
                user.Model = new Model()
                {
                    ObjectState = ObjectState.Added,
                    Active = true
                };
            }

            if (input.IsConsumer)
            {
                user.Consumer = new Consumer()
                {
                    ObjectState = ObjectState.Added,
                    Active = true
                };
            }

            if (input.IsEditor)
            {
                user.Editor = new Editor()
                {
                    ObjectState = ObjectState.Added,
                    Active = true
                };
            }

            if (input.IsProducer)
            {
                user.Producer = new Producer()
                {
                    ObjectState = ObjectState.Added,
                    Active = true
                };
            }

            user.PasswordHash = _passwordHasher.HashPassword(user, input.Password);

            return await CreateAsync(user, CancellationToken.None);

        }

        private Task<User> FindUserAsync(int userId, CancellationToken cancellationToken)
        {
            return Users.SingleOrDefaultAsync(u => u.Id.Equals(userId), cancellationToken);
        }

        private int ConvertIdFromString(string id)
        {
            if (id == null) return default(int);
            return (int)TypeDescriptor.GetConverter(typeof(int)).ConvertFromInvariantString(id)!;
        }

        protected void ThrowIfDisposed()
        {
            if (_disposed) throw new ObjectDisposedException(GetType().Name);
        }
    }
}