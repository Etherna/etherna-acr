using Etherna.ACR.Middlewares.DebugPages.Views;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace Etherna.ACR.Middlewares.DebugPages
{
    public class DebugPagesMiddleware
    {
        private readonly RequestDelegate next;
        private readonly DebugPagesOptions options;

        public DebugPagesMiddleware(
            RequestDelegate next,
            IOptions<DebugPagesOptions> options)
        {
            if (options is null)
                throw new ArgumentNullException(nameof(options));

            this.next = next;
            this.options = options.Value;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context is null)
                throw new ArgumentNullException(nameof(context));

            if (context.Request.Path == options.ConfigurationPagePath)
            {
                var executor = context.RequestServices.GetRequiredService<IActionResultExecutor<ViewResult>>();
                var actionContext = new ActionContext(
                    context,
                    context.GetRouteData() ?? new RouteData(),
                    new Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor());
                var viewResult = new ViewResult()
                {
                    ViewData = new ViewDataDictionary(
                        new EmptyModelMetadataProvider(),
                        new ModelStateDictionary())
                    {
                        Model = new ConfigurationPageModel(
                            context.RequestServices.GetRequiredService<IConfiguration>(), options)
                    },
                    ViewName = "~/Middlewares/DebugPages/Views/ConfigurationPage.cshtml"
                };

                await executor.ExecuteAsync(actionContext, viewResult);
            }
            else if (context.Request.Path == options.RequestPagePath)
            {
                var executor = context.RequestServices.GetRequiredService<IActionResultExecutor<ViewResult>>();
                var actionContext = new ActionContext(
                    context,
                    context.GetRouteData() ?? new RouteData(),
                    new Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor());
                var viewResult = new ViewResult()
                {
                    ViewData = new ViewDataDictionary(
                        new EmptyModelMetadataProvider(),
                        new ModelStateDictionary())
                    {
                        Model = new RequestPageModel(context.Request, options)
                    },
                    ViewName = "~/Middlewares/DebugPages/Views/RequestPage.cshtml"
                };

                await executor.ExecuteAsync(actionContext, viewResult);
            }
            else
            {
                // Call the next delegate/middleware in the pipeline.
                await next(context);
            }
        }
    }
}
