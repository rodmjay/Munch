using Microsoft.Extensions.DependencyInjection.Extensions;
using MunchBase.Administration.Interfaces;
using MunchBase.Administration.Services;
using MunchBase.Channels.Extensions;
using MunchBase.Common.Middleware.Builders;
using MunchBase.Consumers.Extensions;
using MunchBase.Dumps.Extensions;
using MunchBase.Editors.Extensions;
using MunchBase.Media.Extensions;
using MunchBase.Models.Extensions;
using MunchBase.Producers.Extensions;
using MunchBase.Providers.Extensions;

namespace MunchBase.Administration.Extensions
{
    public static class AppBuilderExtensions
    {
        public static AppBuilder AddAdmin(this AppBuilder builder)
        {
            builder.Services.TryAddScoped<IAdminService, AdminService>();
            builder.Services.TryAddScoped<IAdminAccessor, AdminAccessor>();

            builder.AddModelDependencies()
                .AddEditorDependencies()
                .AddChannelDependencies()
                .AddMediaSetDependencies()
                .AddProviderDependencies()
                .AddProducerDependencies()
                .AddConsumerDependencies()
                .AddDumpDependencies();

            return builder;
        }
        
    }
}
