﻿#region Header

// /*
// Copyright (c) 2021 Rod Johnson. All rights reserved.
// Author: Rod Johnson, Architect, Munch
// */

#endregion

using System;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using MunchBase.Common.Middleware.Builders;
using MunchBase.Users.Interfaces;
using MunchBase.Users.Services;

namespace MunchBase.Users.Extensions
{
    public static class AppBuilderExtensions
    {
        public static AppBuilder AddAdminUserDependencies(this AppBuilder builder)
        {
            builder.Services.AddScoped<IUserService, UserService>();
            return builder;
        }

        public static RestApiBuilder AddAuthorization(this RestApiBuilder builder,
            Action<AuthorizationPolicyBuilder> action)
        {
            builder.Services.AddAuthorization(options => { options.AddPolicy("ApiScope", action); });

            return builder;
        }

        public static RestApiBuilder AddBearerAuthentication(this RestApiBuilder builder,
            Action<JwtBearerOptions> action)
        {
            //builder.Services.AddSingleton<IClaimsTransformation, ClaimsTransformer>();
            builder.Services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", action);

            return builder;
        }

        public static WebAppBuilder AddSession(this WebAppBuilder builder)
        {
            builder.Services.AddSession(options =>
            {
                //options.IdleTimeout = TimeSpan.FromSeconds(1000);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            return builder;
        }
    }
}