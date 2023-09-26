using Microsoft.Extensions.DependencyInjection.Extensions;
using MunchBase.Common.Middleware.Builders;
using MunchBase.Media.Interfaces;
using MunchBase.Media.Services;
using MunchBase.Models.Interfaces;
using MunchBase.Models.Services;
using MunchBase.Models.ViewModels;

namespace MunchBase.Media.Extensions
{
    public static class AppBuilderExtensions
    {
        public static AppBuilder AddMediaSetDependencies(this AppBuilder builder)
        {
            builder.Services.TryAddTransient<MediaErrorDescriber>();
            builder.Services.TryAddScoped<IMediaSetService, MediaSetService>();
            builder.Services.TryAddScoped<IModelExcludeCountryService, ModelExcludeCountryService>();

            return builder;
        }
        
    }
}
