#region Header

// /*
// Copyright (c) 2021 Rod Johnson. All rights reserved.
// Author: Rod Johnson, Architect, Munch
// */

#endregion

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MunchBase.Common.Settings;
using MunchBase.Users.Interfaces;

namespace MunchBase.Common.Middleware.Bases
{
    [ApiController]
    [Produces("application/json")]
    [Route("v1.0/[controller]")]
    public class BaseController : ControllerBase
    {
        private readonly IUserAccessor _userAccessor;
        protected readonly AppSettings AppSettings;
        protected readonly IDistributedCache Cache;
        

        /// <param name="serviceProvider"></param>
        protected BaseController(IServiceProvider serviceProvider)
        {
            _userAccessor = serviceProvider.GetRequiredService<IUserAccessor>();
            Cache = serviceProvider.GetRequiredService<IDistributedCache>();
            AppSettings = serviceProvider.GetRequiredService<IOptions<AppSettings>>().Value;

        }


        [ActionContext] public ActionContext ActionContext { get; set; }

        protected async Task<IUser> GetCurrentUser()
        {
            return await _userAccessor.GetUser(User);
        }
    }
}