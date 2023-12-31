﻿#region Header

// /*
// Copyright (c) 2021 Rod Johnson. All rights reserved.
// Author: Rod Johnson, Architect, Munch
// */

#endregion

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MunchBase.Common.Settings;

namespace MunchBase.Common.Middleware.Builders
{
    public class MvcClientBuilder
    {
        public MvcClientBuilder(WebAppBuilder builder)
        {
            Services = builder.Services;
            AppSettings = builder.AppSettings;
            Configuration = builder.Configuration;
            Environment = builder.Environment;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }
        public AppSettings AppSettings { get; set; }

        public IServiceCollection Services { get; }
    }
}