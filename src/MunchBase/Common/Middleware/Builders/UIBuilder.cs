#region Header

// /*
// Copyright (c) 2021 Rod Johnson. All rights reserved.
// Author: Rod Johnson, Architect, Munch
// */

#endregion

using Microsoft.Extensions.DependencyInjection;
using MunchBase.Common.Settings;

namespace MunchBase.Common.Middleware.Builders
{
    public class UIBuilder
    {
        public UIBuilder(WebAppBuilder serviceBuilder)
        {
            Services = serviceBuilder.Services;
            AppSettings = serviceBuilder.AppSettings;
        }

        public AppSettings AppSettings { get; }
        public IServiceCollection Services { get; }
    }
}