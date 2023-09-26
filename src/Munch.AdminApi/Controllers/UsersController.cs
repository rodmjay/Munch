using Microsoft.AspNetCore.Mvc;
using MunchBase.Common.Models;
using MunchBase.Users.Extensions;
using MunchBase.Users.Interfaces;
using MunchBase.Users.ViewModels;

namespace Munch.AdminApi.Controllers;

public class UsersController : BaseAdminController
{
    private readonly IUserService _service;

    public UsersController(IServiceProvider serviceProvider, IUserService service) : base(serviceProvider)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<PagedList<UserDto>> GetUsers([FromQuery] PagingQuery paging, [FromQuery] UserQuery query)
    {
        var user = await GetCurrentUser();
        return await _service.GetUsers<UserDto>(Admin, query.GetExpression(), paging);
    }

    [HttpGet("{userId}")]
    public async Task<UserDto> GetUser([FromRoute] int userId)
    {
        var user = await GetCurrentUser();
        return await _service.GetUser<UserDto>(Admin, userId);
    }

    [HttpPost]
    public Task<Result> CreateUser([FromBody]UserInput input)
    {
        throw new NotImplementedException();
    }
}