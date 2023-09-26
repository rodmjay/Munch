#region Header

// /*
// Copyright (c) 2021 SolutionStream. All rights reserved.
// Author: Rod Johnson, Architect, Munch
// */

#endregion

using Microsoft.Extensions.DependencyInjection;
using MunchBase.Common.Settings;

namespace MunchBase.Common.Middleware.Builders
{
    public class RestApiBuilder
    {
        public RestApiBuilder(WebAppBuilder serviceBuilder)
        {
            Services = serviceBuilder.Services;
            AppSettings = serviceBuilder.AppSettings;
            ConnectionString = serviceBuilder.ConnectionString;
        }

        public string ConnectionString { get; set; }
        public AppSettings AppSettings { get; }
        public IServiceCollection Services { get; }
    }
}