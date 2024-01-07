using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;
using System;

namespace Etherna.ACR.Middlewares.DebugPages
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseEthernaAcrDebugPages(this IApplicationBuilder app)
        {
            ArgumentNullException.ThrowIfNull(app, nameof(app));

            return app.UseMiddleware<DebugPagesMiddleware>();
        }

        public static IApplicationBuilder UseEthernaAcrDebugPages(
            this IApplicationBuilder app,
            DebugPagesOptions options)
        {
            ArgumentNullException.ThrowIfNull(app, nameof(app));
            ArgumentNullException.ThrowIfNull(options, nameof(options));

            return app.UseMiddleware<DebugPagesMiddleware>(Options.Create(options));
        }
    }
}
