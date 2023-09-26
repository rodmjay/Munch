#region Header

// /*
// Copyright (c) 2021 Rod Johnson. All rights reserved.
// Author: Rod Johnson, Architect, Munch
// */

#endregion

using Microsoft.Extensions.DependencyInjection.Extensions;
using MunchBase.Common.Middleware.Builders;
using MunchBase.Geography.Interfaces;
using MunchBase.Geography.Services;
using MunchBase.Geography.ViewModels;

namespace MunchBase.Geography.Extensions
{
    public static class AppBuilderExtensions
    {
        public static AppBuilder AddGeographyDependencies(this AppBuilder builder)
        {
            builder.Services.TryAddTransient<GeographyErrorDescriber>();
            builder.Services.TryAddScoped<ICountryService, CountryService>();
            builder.Services.TryAddScoped<IEnabledCountryService, EnabledCountryService>();

            return builder;
        }
    }
}