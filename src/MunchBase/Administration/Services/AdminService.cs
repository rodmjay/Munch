using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using MunchBase.Administration.Entities;
using MunchBase.Administration.Interfaces;
using MunchBase.Administration.ViewModels;
using MunchBase.Common.Services.Bases;

namespace MunchBase.Administration.Services
{
    public class AdminService : BaseService<Admin>, IAdminService
    {
        public Task<T> GetAdmin<T>(IAdmin admin) where T : AdminDto
        {
            return Repository.Queryable().Where(x => x.Id == admin.Id).ProjectTo<T>(ProjectionMapping)
                .FirstAsync();
        }

        public AdminService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }
    }
}
