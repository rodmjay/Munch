using Microsoft.Extensions.DependencyInjection.Extensions;
using MunchBase.Common.Middleware.Builders;
using MunchBase.Tasks.Interfaces;
using MunchBase.Tasks.Services;

namespace MunchBase.Tasks.Extensions
{
    public static class AppBuilderExtensions
    {
        public static AppBuilder AddModelTaskDependencies(this AppBuilder builder)
        {
            builder.Services.TryAddScoped<ITaskService, TaskService>();

            return builder;
        }
    }
}
