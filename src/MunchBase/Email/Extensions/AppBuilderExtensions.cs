#region Header

// /*
// Copyright (c) 2021 Rod Johnson. All rights reserved.
// Author: Rod Johnson, Architect, Munch
// */

#endregion

using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MunchBase.Common.Middleware.Builders;
using MunchBase.Common.Settings;
using MunchBase.Email.Services;
using SendGrid;

namespace MunchBase.Email.Extensions
{
    public static class AppBuilderExtensions
    {
        public static AppBuilder WithNoopEmailSender(this AppBuilder builder)
        {
            builder.Services.AddScoped<IEmailSender, NoopEmailSender>();
            return builder;
        }

        public static AppBuilder WithSendgridEmailSender(this AppBuilder builder)
        {
            builder.Services.AddSingleton(sp =>
            {
                var appSettings = sp.GetRequiredService<IOptions<AppSettings>>();
                return new SendGridClient(appSettings.Value.SendGrid.ApiKey);
            });

            builder.Services.AddScoped<IEmailSender, SendgridEmailSender>();

            return builder;
        }
    }
}