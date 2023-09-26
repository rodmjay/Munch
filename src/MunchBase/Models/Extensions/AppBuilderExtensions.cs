#region Header

// /*
// Copyright (c) 2021 Rod Johnson. All rights reserved.
// Author: Rod Johnson, Architect, Munch
// */

#endregion

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MunchBase.Channels.Extensions;
using MunchBase.Common.Middleware.Builders;
using MunchBase.Editors.Extensions;
using MunchBase.Media.Extensions;
using MunchBase.Models.Interfaces;
using MunchBase.Models.Services;
using MunchBase.Models.ViewModels;
using MunchBase.Producers.Extensions;
using MunchBase.Providers.Extensions;

namespace MunchBase.Models.Extensions
{
    public static class AppBuilderExtensions
    {
        public static AppBuilder AddModel(this AppBuilder builder)
        {
            builder.Services.AddScoped<IModelAccessor, ModelAccessor>();

            builder.AddModelDependencies()
                .AddEditorDependencies()
                .AddProducerDependencies()
                .AddMediaSetDependencies()
                .AddProviderDependencies()
                .AddChannelDependencies();

            return builder;
        }
        public static AppBuilder AddModelDependencies(this AppBuilder builder)
        {
            builder.Services.TryAddTransient<ModelErrorDescriber>();
            builder.Services.TryAddScoped<IModelService, ModelService>();
            builder.Services.TryAddScoped<IFeaturedModelService, FeaturedModelService>();
            builder.Services.TryAddScoped<IModelExcludeCountryService, ModelExcludeCountryService>();
            builder.Services.TryAddScoped<IModelSubscriberService, ModelSubscriberService>();

            return builder;
        }
        
    }
}