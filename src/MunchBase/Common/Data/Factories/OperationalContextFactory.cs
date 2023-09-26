#region Header

// /*
// Copyright (c) 2021 SolutionStream. All rights reserved.
// Author: Rod Johnson, Architect, Munch
// */

#endregion

using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MunchBase.Common.Data.Contexts;
using MunchBase.Common.Data.Interfaces;

namespace MunchBase.Common.Data.Factories
{
    public class OperationalContextFactory : IApplicationContextFactory
    {
        public ApplicationContext CreateDbContext(string[] args)
        {
            // Used only for EF .NET Core CLI tools (update database/migrations etc.)
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
                .AddJsonFile("sharedSettings.json", false, true);

            var config = builder.Build();

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>()
                .EnableSensitiveDataLogging()
                .UseSqlServer(config.GetConnectionString("DefaultConnection"));

            return new ApplicationContext(optionsBuilder.Options);
        }
    }
}