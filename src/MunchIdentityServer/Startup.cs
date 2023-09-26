#region Header

// /*
// Copyright (c) 2021 Rod Johnson. All rights reserved.
// Author: Rod Johnson, Architect, Munch
// */

#endregion

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MunchBase.Common.Data.Contexts;
using MunchBase.Common.Middleware.Extensions;
using MunchBase.Email.Extensions;
using MunchBase.IdentityServer.Extensions;
using MunchBase.Users.Extensions;

namespace Munch.IdentityServer
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IWebHostEnvironment Environment { get; }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var builder = services.ConfigureApp(Configuration, Environment)
                .AddDatabase<ApplicationContext>()
                .AddIdentity()
                .AddAutomapperProfilesFromAssemblies()
                .AddCaching()
                .AddUserDependencies();

            if (Environment.IsDevelopment())
                builder.WithNoopEmailSender();
            else
                builder.WithSendgridEmailSender();

            var webBuilder = builder.ConfigureWebApp(Environment)
                .AddUserAccessor()
                .AddAuthorization(policy => { policy.RequireAuthenticatedUser(); })
                .AddSigninDependencies();
            ;

            var restBuilder = webBuilder.ConfigureRest();


            var idBuilder = webBuilder.ConfigureIdentityServer();

            var uiBuilder = webBuilder.ConfigureUI(options =>
                {
                    options.Conventions.AuthorizeFolder("/Account/Manage", "ApiScope");
                })
                .AddCookies()
                .AddSession()
                .AddAntiForgery()
                .AddAuthentication();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ApplicationContext context)
        {
            IdentityBuilderExtensions.Configure(app, env, context);
        }
    }
}