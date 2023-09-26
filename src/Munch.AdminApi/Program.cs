#region Header

// /*
// Copyright (c) 2021 SolutionStream. All rights reserved.
// Author: Rod Johnson, Architect, Munch
// */

#endregion

using System.Diagnostics.CodeAnalysis;
using MunchBase.Common.Middleware.Extensions;
using Serilog;

namespace Munch.AdminApi
{
    [ExcludeFromCodeCoverage]
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildHost(args)
                .Init();
        }

        public static IHostBuilder BuildHost(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(HostBuilderExtensions.Configure)
                .ConfigureWebHostDefaults(builder =>
                {
                    builder
                        .ConfigureLogging(HostBuilderExtensions.ConfigureLogging)
                        .UseSerilog()
                        .UseStartup<Startup>();
                });
        }
    }
}