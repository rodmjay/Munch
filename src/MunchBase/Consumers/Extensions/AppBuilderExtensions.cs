using Microsoft.Extensions.DependencyInjection.Extensions;
using MunchBase.Channels.Extensions;
using MunchBase.Common.Middleware.Builders;
using MunchBase.Consumers.Interfaces;
using MunchBase.Consumers.Services;
using MunchBase.Media.Extensions;
using MunchBase.Models.Extensions;

namespace MunchBase.Consumers.Extensions
{
    public static class AppBuilderExtensions
    {
        public static AppBuilder AddConsumer(this AppBuilder builder)
        {
            builder.Services.TryAddScoped<IConsumerAccessor, ConsumerAccessor>();

            builder.AddConsumerDependencies()
                .AddModelDependencies()
                .AddChannelDependencies()
                .AddMediaSetDependencies();

            return builder;
        }

        public static AppBuilder AddConsumerDependencies(this AppBuilder builder)
        {
            builder.Services.TryAddScoped<IConsumerService, ConsumerService>();
            
            return builder;
        }
    }
}
