using System;
using System.Linq;
using System.Security.Claims;
using AutoMapper.QueryableExtensions;
using MunchBase.Administration.Entities;
using MunchBase.Administration.Interfaces;
using MunchBase.Administration.ViewModels;
using MunchBase.Common.Services.Bases;
using MunchBase.Users.Managers;

namespace MunchBase.Administration.Services
{

    public class AdminAccessor : BaseService<Admin>, IAdminAccessor
    {
        private readonly UserManager _userManager;

        public AdminAccessor(
            UserManager userManager,
            IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _userManager = userManager;
        }

        public IAdmin GetAdmin(ClaimsPrincipal principal)
        {
            var id = _userManager.GetUserId(principal);

            var userId = int.Parse(id);

            return Repository.Queryable().Where(x => x.Id == userId)
                .ProjectTo<AdminDto>(ProjectionMapping)
                .Cast<IAdmin>()
                .First();
        }
    }
}
