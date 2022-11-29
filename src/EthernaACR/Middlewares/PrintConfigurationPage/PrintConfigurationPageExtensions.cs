using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;
using System;

namespace Etherna.ACR.Middlewares.PrintConfigurationPage
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UsePrintConfigurationPage(this IApplicationBuilder app)
        {
            if (app == null)
                throw new ArgumentNullException(nameof(app));

            return app.UseMiddleware<PrintConfigurationPageMiddleware>();
        }

        public static IApplicationBuilder UsePrintConfigurationPage(
            this IApplicationBuilder app,
            PrintConfigurationPageOptions options)
        {
            if (app == null)
                throw new ArgumentNullException(nameof(app));
            if (options == null)
                throw new ArgumentNullException(nameof(options));

            return app.UseMiddleware<PrintConfigurationPageMiddleware>(Options.Create(options));
        }
    }
}
