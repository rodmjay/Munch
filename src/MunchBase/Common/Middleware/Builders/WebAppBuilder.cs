﻿#region Header

// /*
// Copyright (c) 2021 Rod Johnson. All rights reserved.
// Author: Rod Johnson, Architect, Munch
// */

#endregion

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MunchBase.Common.Settings;

namespace MunchBase.Common.Middleware.Builders
{
    [ExcludeFromCodeCoverage]
    public class WebAppBuilder
    {
        public WebAppBuilder(
            AppBuilder appBuilder,
            IWebHostEnvironment environment)
        {
            Environment = environment;
            AppSettings = appBuilder.AppSettings;
            Services = appBuilder.Services;
            Configuration = appBuilder.Configuration;
            ConnectionString = appBuilder.ConnectionString;
            AssembliesToMap = appBuilder.AssembliesToMap;
        }

        public IWebHostEnvironment Environment { get; }
        public List<string> AssembliesToMap { get; set; }
        public IServiceCollection Services { get; }
        public IConfiguration Configuration { get; }
        public string ConnectionString { get; set; }
        public AppSettings AppSettings { get; set; }
    }
}