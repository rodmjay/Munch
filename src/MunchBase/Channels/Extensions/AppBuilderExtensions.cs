using Microsoft.Extensions.DependencyInjection.Extensions;
using MunchBase.Channels.Interfaces;
using MunchBase.Channels.Services;
using MunchBase.Common.Middleware.Builders;

namespace MunchBase.Channels.Extensions
{
    public static class AppBuilderExtensions
    {
        public static AppBuilder AddChannelDependencies(this AppBuilder builder)
        {
            builder.Services.TryAddScoped<IChannelService, ChannelService>();

            return builder;
        }
        
    }
}
