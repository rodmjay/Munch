using System;
using System.Linq;
using System.Security.Claims;
using AutoMapper.QueryableExtensions;
using MunchBase.Common.Services.Bases;
using MunchBase.Models.Entities;
using MunchBase.Models.Interfaces;
using MunchBase.Models.ViewModels;
using MunchBase.Users.Managers;

namespace MunchBase.Models.Services;

public class ModelAccessor : BaseService<Model>, IModelAccessor
{
    private readonly UserManager _userManager;

    public ModelAccessor(
        UserManager userManager,
        IServiceProvider serviceProvider) : base(serviceProvider)
    {
        _userManager = userManager;
    }

    public IModel GetModel(ClaimsPrincipal principal)
    {
        var id = _userManager.GetUserId(principal);

        var userId = int.Parse(id);

        return Repository.Queryable().Where(x => x.Id == userId)
            .ProjectTo<ModelDto>(ProjectionMapping)
            .Cast<IModel>()
            .First();
    }
}