// Copyright 2021-present Etherna Sa
// 
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
// 
//       http://www.apache.org/licenses/LICENSE-2.0
// 
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.

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
            ArgumentNullException.ThrowIfNull(options, nameof(options));

            this.next = next;
            this.options = options.Value;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            ArgumentNullException.ThrowIfNull(context, nameof(context));

            if (context.Request.Path == options.ConfigurationPagePath)
            {
                var executor = context.RequestServices.GetRequiredService<IActionResultExecutor<ViewResult>>();
                var actionContext = new ActionContext(
                    context,
                    context.GetRouteData(),
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
                    context.GetRouteData(),
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
