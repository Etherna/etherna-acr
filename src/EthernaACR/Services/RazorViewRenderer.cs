// Copyright 2021-present Etherna SA
// This file is part of Etherna ACR.
// 
// Etherna ACR is free software: you can redistribute it and/or modify it under the terms of the
// GNU Lesser General Public License as published by the Free Software Foundation,
// either version 3 of the License, or (at your option) any later version.
// 
// Etherna ACR is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY;
// without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
// See the GNU Lesser General Public License for more details.
// 
// You should have received a copy of the GNU Lesser General Public License along with Etherna ACR.
// If not, see <https://www.gnu.org/licenses/>.

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Routing;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Etherna.ACR.Services
{
    public class RazorViewRenderer(
        IServiceProvider serviceProvider,
        ITempDataProvider tempDataProvider,
        IRazorViewEngine viewEngine)
        : IRazorViewRenderer
    {
        // Methods.
        public async Task<string> RenderViewToStringAsync<TModel>(
            string viewName,
            TModel model,
            ActionContext? actionContext = null)
        {
            actionContext ??= new ActionContext(new DefaultHttpContext
            {
                RequestServices = serviceProvider
            }, new RouteData(), new ActionDescriptor());

            var view = FindView(actionContext, viewName);

            using var output = new StringWriter();

            var viewContext = new ViewContext(
                actionContext,
                view,
                new ViewDataDictionary<TModel>(
                    metadataProvider: new EmptyModelMetadataProvider(),
                    modelState: new ModelStateDictionary())
                { Model = model },
                new TempDataDictionary(
                    actionContext.HttpContext,
                    tempDataProvider),
                output,
                new HtmlHelperOptions());

            await view.RenderAsync(viewContext);

            return output.ToString();
        }

        // Helpers.
        private IView FindView(ActionContext actionContext, string viewName)
        {
            var getViewResult = viewEngine.GetView(
                executingFilePath: null,
                viewPath: viewName,
                isMainPage: true);

            if (getViewResult.Success)
                return getViewResult.View;

            var findViewResult = viewEngine.FindView(
                actionContext,
                viewName,
                isMainPage: true);

            if (findViewResult.Success)
                return findViewResult.View;

            var searchedLocations = getViewResult.SearchedLocations.Concat(findViewResult.SearchedLocations);
            var errorMessage = string.Join(
                Environment.NewLine,
                new[] { $"Unable to find view '{viewName}'. The following locations were searched:" }.Concat(searchedLocations));

            throw new InvalidOperationException(errorMessage);
        }
    }
}
