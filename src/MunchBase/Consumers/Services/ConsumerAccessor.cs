using System;
using System.Linq;
using System.Security.Claims;
using AutoMapper.QueryableExtensions;
using MunchBase.Common.Services.Bases;
using MunchBase.Consumers.Entities;
using MunchBase.Consumers.Interfaces;
using MunchBase.Consumers.ViewModels;
using MunchBase.Users.Managers;

namespace MunchBase.Consumers.Services
{
    public class ConsumerAccessor : BaseService<Consumer>, IConsumerAccessor
    {
        private readonly UserManager _userManager;

        public ConsumerAccessor(
            UserManager userManager,
            IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _userManager = userManager;
        }

        public IConsumer GetConsumer(ClaimsPrincipal principal)
        {
            var id = _userManager.GetUserId(principal);

            var userId = int.Parse(id);

            return Repository.Queryable().Where(x => x.Id == userId)
                .ProjectTo<ConsumerDto>(ProjectionMapping)
                .Cast<IConsumer>()
                .First();
        }
    }
}
