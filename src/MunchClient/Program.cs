#region Header

// /*
// Copyright (c) 2021 SolutionStream. All rights reserved.
// Author: Rod Johnson, Architect, Solution Stream
// */

#endregion

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TemplateBase.Common.Middleware.Extensions;

namespace TemplateClient
{
    public class Program
    {
        private static void Main(string[] args)
        {
            CreateHostBuilder(args).Init();
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(HostBuilderExtensions.Configure)
                .ConfigureServices((hostBuilderContext, services) =>
                {
                    services.ConfigureApp(hostBuilderContext.Configuration, hostBuilderContext.HostingEnvironment);
                    services.AddHostedService<Worker>();
                });
        }
    }
}