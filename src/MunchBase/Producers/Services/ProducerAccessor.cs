using System;
using System.Linq;
using System.Security.Claims;
using AutoMapper.QueryableExtensions;
using MunchBase.Common.Services.Bases;
using MunchBase.Producers.Entities;
using MunchBase.Producers.Interfaces;
using MunchBase.Producers.ViewModels;
using MunchBase.Users.Managers;

namespace MunchBase.Producers.Services;

public class ProducerAccessor : BaseService<Producer>, IProducerAccessor
{
    private readonly UserManager _userManager;

    public ProducerAccessor(UserManager userManager, IServiceProvider serviceProvider) : base(serviceProvider)
    {
        _userManager = userManager;
    }

    public IProducer GetProducer(ClaimsPrincipal principal)
    {
        var id = _userManager.GetUserId(principal);

        var userId = int.Parse(id);

        return Repository.Queryable().Where(x => x.Id == userId)
            .ProjectTo<ProducerDto>(ProjectionMapping)
            .Cast<IProducer>()
            .First();
    }
}