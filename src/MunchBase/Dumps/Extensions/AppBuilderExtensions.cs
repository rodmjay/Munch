using Microsoft.Extensions.DependencyInjection.Extensions;
using MunchBase.Common.Middleware.Builders;
using MunchBase.Dumps.Interfaces;
using MunchBase.Dumps.Services;

namespace MunchBase.Dumps.Extensions
{
    public static class AppBuilderExtensions
    {
        public static AppBuilder AddDumpDependencies(this AppBuilder builder)
        {
            builder.Services.TryAddScoped<IDumpService, DumpService>();

            return builder;
        }
    }
}
