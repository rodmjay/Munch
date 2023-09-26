#region Header

// /*
// Copyright (c) 2021 Rod Johnson. All rights reserved.
// Author: Rod Johnson, Architect, Munch
// */

#endregion

using Microsoft.Extensions.DependencyInjection.Extensions;
using MunchBase.Common.Middleware.Builders;
using MunchBase.TextMessages.Services;
using Twilio;

namespace MunchBase.TextMessages.Extensions
{
    public static class AppBuilderExtensions
    {
        public static AppBuilder AddTwilio(this AppBuilder builder)
        {
            TwilioClient.Init(builder.AppSettings.Twilio.AccountSid, builder.AppSettings.Twilio.AuthToken);

            builder.Services.TryAddScoped<TwilioSmsService>();

            return builder;
        }
    }
}