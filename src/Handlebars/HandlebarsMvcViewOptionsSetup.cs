﻿using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace HandlebarsViewEngine
{
    public class HandlebarsMvcViewOptionsSetup : IConfigureOptions<MvcViewOptions>
    {
        private readonly IHandlebarsViewEngine _handlebarsViewEngine;

        /// <summary>
        /// Initializes a new instance of <see cref="HandlebarsMvcViewOptionsSetup"/>.
        /// </summary>
        /// <param name="HandlebarsViewEngine">The <see cref="IHandlebarsViewEngine"/>.</param>
        public HandlebarsMvcViewOptionsSetup(IHandlebarsViewEngine HandlebarsViewEngine)
        {
            if (HandlebarsViewEngine == null)
            {
                throw new ArgumentNullException(nameof(HandlebarsViewEngine));
            }

            _handlebarsViewEngine = HandlebarsViewEngine;
        }

        /// <summary>
        /// Configures <paramref name="options"/> to use <see cref="HandlebarsViewEngine"/>.
        /// </summary>
        /// <param name="options">The <see cref="MvcViewOptions"/> to configure.</param>
        public void Configure(MvcViewOptions options)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            options.ViewEngines.Add(_handlebarsViewEngine);
        }

    }
}
