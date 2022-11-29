using Etherna.ACR.Middlewares.PrintConfigurationPage.Views;
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

namespace Etherna.ACR.Middlewares.PrintConfigurationPage
{
    public class PrintConfigurationPageMiddleware
    {
        private readonly RequestDelegate next;
        private readonly PrintConfigurationPageOptions options;

        public PrintConfigurationPageMiddleware(
            RequestDelegate next,
            IOptions<PrintConfigurationPageOptions> options)
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

            if (context.Request.Path == options.PagePath)
            {
                var viewResult = new ViewResult()
                {
                    ViewName = "~/Middlewares/PrintConfigurationPage/Views/PrintConfigurationPage.cshtml"
                };

                var viewDataDictionary = new ViewDataDictionary(
                    new EmptyModelMetadataProvider(),
                    new ModelStateDictionary())
                {
                    Model = new PrintConfigurationPageModel(
                        context.RequestServices.GetRequiredService<IConfiguration>(), options)
                };
                viewResult.ViewData = viewDataDictionary;

                var executor = context.RequestServices.GetRequiredService<IActionResultExecutor<ViewResult>>();
                var actionContext = new ActionContext(
                    context,
                    context.GetRouteData() ?? new RouteData(),
                    new Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor());

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
