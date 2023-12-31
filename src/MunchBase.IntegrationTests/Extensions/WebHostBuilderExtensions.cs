﻿#region Header

// /*
// Copyright (c) 2021 SolutionStream. All rights reserved.
// Author: Rod Johnson, Architect, Solution Stream
// */

#endregion

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using TemplateBase.Common.Extensions;
using TemplateBase.Common.Middleware.Extensions;

namespace TemplateBase.IntegrationTests.Extensions
{
    public static class CustomWebHostBuilderExtensions
    {
        public static void Configure<TFixture>(WebHostBuilderContext hostingContext,
            IConfigurationBuilder config)
        {
            var env = hostingContext.HostingEnvironment;
            var sharedSettingsAssembly = typeof(HostBuilderExtensions).Assembly;
            var integrationTestAssembly = typeof(TFixture).Assembly;

            config
                .AddEmbeddedJsonFile(sharedSettingsAssembly, "sharedSettings.json")
                .AddEmbeddedJsonFile(sharedSettingsAssembly, $"sharedSettings.{env.EnvironmentName}.json", true)
                .AddEmbeddedJsonFile(integrationTestAssembly, "appsettings.json", true)
                .AddEmbeddedJsonFile(integrationTestAssembly, $"appsettings.{env.EnvironmentName}.json", true);

            config
                .AddEnvironmentVariables()
                .Build();
        }
    }
}