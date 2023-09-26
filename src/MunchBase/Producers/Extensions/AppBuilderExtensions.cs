using Microsoft.Extensions.DependencyInjection;
using MunchBase.Common.Middleware.Builders;
using MunchBase.Dumps.Extensions;
using MunchBase.Editors.Extensions;
using MunchBase.Models.Extensions;
using MunchBase.Producers.Interfaces;
using MunchBase.Producers.Services;

namespace MunchBase.Producers.Extensions
{
    public static class AppBuilderExtensions
    {
        public static AppBuilder AddProducer(this AppBuilder builder)
        {
            builder.Services.AddScoped<IProducerAccessor, ProducerAccessor>();
            
            builder.AddModelDependencies()
                .AddDumpDependencies()
                .AddEditorDependencies()
                .AddProducerDependencies();
            
            return builder;
        }

        public static AppBuilder AddProducerDependencies(this AppBuilder builder)
        {
            builder.Services.AddScoped<IProducerService, ProducerService>();
            

            return builder;
        }
    }
}
