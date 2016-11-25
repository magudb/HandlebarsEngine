﻿using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Handlebars
{
    public static class MvcViewFeaturesMvcBuilderExtensions
    {
        public static IMvcBuilder AddHandlbars(this IMvcBuilder builder, Action<HandlebarsViewEngineOptions> setupAction = null)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.Services.AddOptions();
            builder.Services.AddTransient<IConfigureOptions<HandlebarsViewEngineOptions>, HandlebarsViewEngineOptionsSetup>();

            if (setupAction != null)
            {
                builder.Services.Configure(setupAction);
            }

            builder.Services.AddTransient<IConfigureOptions<MvcViewOptions>, HandlebarsMvcViewOptionsSetup>();
            var tempDirectoryProvider = new HandlebarsTempDirectoryProvider();
            builder.Services.AddSingleton<IHandlebarsTempDirectoryProvider>(tempDirectoryProvider);
            builder.Services.AddSingleton<IHandlebarsRendering, HandlebarsRendering>();
            builder.Services.AddSingleton<IHandlebarsViewEngine, HandlebarsViewEngine>();
            builder.Services.AddNodeServices((options) =>
            {
                //options.ProjectPath = tempDirectoryProvider.TempDirectory;
            });
            return builder;

        }
    }
}
