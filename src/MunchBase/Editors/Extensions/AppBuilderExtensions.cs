using Microsoft.Extensions.DependencyInjection;
using MunchBase.Channels.Extensions;
using MunchBase.Common.Middleware.Builders;
using MunchBase.Dumps.Extensions;
using MunchBase.Editors.Interfaces;
using MunchBase.Editors.Services;
using MunchBase.Media.Extensions;
using MunchBase.Models.Extensions;

namespace MunchBase.Editors.Extensions
{
    public static class AppBuilderExtensions
    {
        public static AppBuilder AddEditor(this AppBuilder builder)
        {
            builder.Services.AddScoped<IEditorAccessor, EditorAccessor>();

            builder
                .AddEditorDependencies()
                .AddModelDependencies()
                .AddDumpDependencies()
                .AddChannelDependencies()
                .AddMediaSetDependencies();

            return builder;
        }

        public static AppBuilder AddEditorDependencies(this AppBuilder builder)
        {
            builder.Services.AddScoped<IEditorService, EditorService>();
            

            return builder;
        }
    }
}
