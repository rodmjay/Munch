#region Header

// /*
// Copyright (c) 2021 Rod Johnson. All rights reserved.
// Author: Rod Johnson, Architect, Munch
// */

#endregion

using MunchBase.Common.Caching;
using MunchBase.Common.Data;
using MunchBase.Email.Settings;
using MunchBase.TextMessages.Settings;

namespace MunchBase.Common.Settings
{
    public class AppSettings
    {
        public string ApiUrl { get; set; }
        public string JsClientUrl { get; set; }
        public string MvcClientUrl { get; set; }
        public string Name { get; set; }
        public string Authority { get; set; }
        public string Audience { get; set; }
        public DatabaseSettings Database { get; set; }
        public CacheSettings Cache { get; set; }
        public SendGridSettings SendGrid { get; set; }
        public TwilioSettings Twilio { get; set; }
        public string CodeSigningThumbprint { get; set; }

        public string IdentityEndpoint => ApiUrl + "/v1.0/identity";
    }
}