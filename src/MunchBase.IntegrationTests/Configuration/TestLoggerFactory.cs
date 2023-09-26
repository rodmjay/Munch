#region Header

// /*
// Copyright (c) 2021 SolutionStream. All rights reserved.
// Author: Rod Johnson, Architect, Solution Stream
// */

#endregion

using System;
using Microsoft.Extensions.Logging;

namespace TemplateBase.IntegrationTests.Configuration
{
    public static class TestLoggerFactory
    {
        public static Lazy<ILogger> Instance { get; } = new(BuildLogger);

        private static ILogger BuildLogger()
        {
            var factory = LoggerFactory.Create(c =>
            {
                c.AddFilter("Microsoft", LogLevel.Debug)
                    .AddFilter("Default", LogLevel.Debug)
                    .AddFilter("System", LogLevel.Debug)
                    .AddConsole()
                    .AddEventSourceLogger()
                    .AddDebug();
            });

            return factory.CreateLogger("Integration Tests");
        }
    }
}