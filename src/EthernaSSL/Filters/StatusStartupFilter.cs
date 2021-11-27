using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using System;

namespace Etherna.SSL.Filters
{
    public class StatusStartupFilter : IStartupFilter
    {
        public bool Executed { get; set; }

        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next) =>
            app =>
            {
                app.Use(async (context, next) =>
                {
                    if (context.Request.Path == "/status")
                        context.Response.StatusCode = 200;
                    else
                        await next.Invoke();
                });
                next(app);
            };
    }
}
