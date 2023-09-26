using Microsoft.Extensions.DependencyInjection.Extensions;
using MunchBase.Common.Middleware.Builders;
using MunchBase.Providers.Interfaces;
using MunchBase.Providers.Services;

namespace MunchBase.Providers.Extensions
{
    public static class AppBuilderExtensions
    {
        public static AppBuilder AddProviderDependencies(this AppBuilder builder)
        {
            builder.Services.TryAddScoped<IProviderService, ProviderService>();

            return builder;
        }
    }
}
