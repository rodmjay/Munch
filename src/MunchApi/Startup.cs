#region Header

// /*
// Copyright (c) 2021 SolutionStream. All rights reserved.
// Author: Rod Johnson, Architect, Solution Stream
// */

#endregion

using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using TemplateBase.Common.Data.Contexts;
using TemplateBase.Common.Middleware.Extensions;
using TemplateBase.Common.Settings;
using TemplateBase.Geography.Extensions;
using TemplateBase.Users.Extensions;

namespace TemplateApi
{
    public class Startup
    {
        private readonly HttpMessageHandler _identityServerMessageHandler;

        public Startup(IConfiguration configuration, IWebHostEnvironment environment,
            HttpMessageHandler identityServerMessageHandler = null)
        {
            _identityServerMessageHandler = identityServerMessageHandler;
            Configuration = configuration;
            Environment = environment;
        }

        public IWebHostEnvironment Environment { get; }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var builder = services.ConfigureApp(Configuration, Environment)
                .AddDatabase<ApplicationContext>()
                .AddAutomapperProfilesFromAssemblies()
                .AddCaching()
                .AddUserDependencies()
                .AddGeographyDependencies();

            var webAppBuilder = builder.ConfigureWebApp(Environment);

            var restBuilder = webAppBuilder.ConfigureRest()
                .AddAuthorization(policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.RequireClaim("scope", builder.AppSettings.Audience);
                    policy.RequireClaim("scope", "openid");
                    policy.RequireClaim("scope", "profile");
                })
                .AddBearerAuthentication(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.Authority = builder.AppSettings.Authority;
                    options.Audience = builder.AppSettings.Audience;

                    if (_identityServerMessageHandler != null)
                        options.BackchannelHttpHandler = _identityServerMessageHandler;

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = false,
                        ValidAudience = builder.AppSettings.Audience,

                        NameClaimType = "name",
                        RoleClaimType = "role"
                    };

                    options.Events = new JwtBearerEvents
                    {
                        OnAuthenticationFailed = c =>
                        {
                            var logger = c.HttpContext.RequestServices.GetRequiredService<ILogger<StartupBase>>();
                            logger.LogTrace("Authentication Failure");
                            return Task.FromResult(0);
                        },
                        OnTokenValidated = c =>
                        {
                            var logger = c.HttpContext.RequestServices.GetRequiredService<ILogger<StartupBase>>();
                            logger.LogTrace("Authentication Success");
                            return Task.FromResult(0);
                        }
                    };
                })
                .AddSwagger(Assembly.GetAssembly(GetType()))
                .AddCors(builder.AppSettings.JsClientUrl,
                    builder.AppSettings.Authority,
                    builder.AppSettings.MvcClientUrl);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ApplicationContext context,
            IOptions<AppSettings> settings)
        {
            RestApiBuilderExtensions.Configure(app, env, context, settings);
        }
    }
}