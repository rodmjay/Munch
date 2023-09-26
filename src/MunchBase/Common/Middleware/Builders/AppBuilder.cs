#region Header

// /*
// Copyright (c) 2021 SolutionStream. All rights reserved.
// Author: Rod Johnson, Architect, Munch
// */

#endregion

using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MunchBase.Common.Settings;

namespace MunchBase.Common.Middleware.Builders
{
    public class AppBuilder
    {
        public AppBuilder(
            IServiceCollection services,
            AppSettings settings,
            IHostEnvironment environment,
            IConfiguration configuration)
        {
            Services = services;
            Configuration = configuration;
            AppSettings = settings;
            HostEnvironment = environment;
            AssembliesToMap = new List<string>();
        }

        public IHostEnvironment HostEnvironment { get; set; }
        public List<string> AssembliesToMap { get; set; }
        public IServiceCollection Services { get; }
        public IConfiguration Configuration { get; }
        public string ConnectionString { get; set; }
        public AppSettings AppSettings { get; set; }
        public string AzureStorageConnectionString { get; set; }
        public string AzureServiceBusConnectionString { get; set; }

    }
}