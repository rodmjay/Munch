#region Header

// /*
// Copyright (c) 2021 SolutionStream. All rights reserved.
// Author: Rod Johnson, Architect, Munch
// */

#endregion

using Microsoft.Extensions.Options;
using MunchBase.TextMessages.Settings;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace MunchBase.TextMessages.Services
{
    public class TwilioSmsService
    {
        private readonly TwilioSettings _settings;

        public TwilioSmsService(IOptions<TwilioSettings> settings)
        {
            _settings = settings.Value;
        }

        public void SendMessage()
        {
            var message = MessageResource.Create(new PhoneNumber(""), from: new PhoneNumber(""));
        }
    }
}