using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;
using System;

namespace Etherna.ACR.Middlewares.DebugPages
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseEthernaAcrDebugPages(this IApplicationBuilder app)
        {
            if (app == null)
                throw new ArgumentNullException(nameof(app));

            return app.UseMiddleware<DebugPagesMiddleware>();
        }

        public static IApplicationBuilder UseEthernaAcrDebugPages(
            this IApplicationBuilder app,
            DebugPagesOptions options)
        {
            if (app == null)
                throw new ArgumentNullException(nameof(app));
            if (options == null)
                throw new ArgumentNullException(nameof(options));

            return app.UseMiddleware<DebugPagesMiddleware>(Options.Create(options));
        }
    }
}
