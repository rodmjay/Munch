using System;
using System.Threading.Tasks;
using System.Xml.XPath;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MunchBase.Common.Middleware.Bases;
using MunchBase.Common.Models;
using MunchBase.Tasks.Entities;
using MunchBase.Users.Interfaces;
using MunchBase.Users.Managers;
using MunchBase.Users.ViewModels;

namespace Munch.IdentityServer.Controllers
{
    public class UsersController : BaseController
    {
        private readonly IUserService _userService;

        public UsersController(IServiceProvider serviceProvider, IUserService userService) : base(serviceProvider)
        {
            _userService = userService;
        }

        [HttpPost]
        [AllowAnonymous]
        public Task<IdentityResult> CreateUser(UserInput input)
        {
            return _userService.CreateUser(input);
        }
    }
}
