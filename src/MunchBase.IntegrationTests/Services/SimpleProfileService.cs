﻿#region Header

// /*
// Copyright (c) 2021 SolutionStream. All rights reserved.
// Author: Rod Johnson, Architect, Solution Stream
// */

#endregion

using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Services;

namespace TemplateBase.IntegrationTests.Services
{
    public class SimpleProfileService : IProfileService

    {
        public Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var subject = context.Subject.Claims.First(claim => claim.Type == JwtClaimTypes.Subject).Value;

            context.IssuedClaims = new List<Claim>
            {
                new(JwtClaimTypes.Subject, subject),
                new(JwtClaimTypes.Scope, "profile"),
                new(JwtClaimTypes.Scope, "openid"),
                new(JwtClaimTypes.Scope, "api1")
            };

            return Task.CompletedTask;
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            context.IsActive = true;
            return Task.CompletedTask;
        }
    }
}