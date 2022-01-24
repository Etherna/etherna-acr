//   Copyright 2021-present Etherna Sagl
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

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Etherna.ACR.Services
{
    public class RazorViewRenderer : IRazorViewRenderer
    {
        // Fields.
        private readonly IActionContextAccessor actionContextAccessor;
        private readonly ITempDataProvider tempDataProvider;
        private readonly IRazorViewEngine viewEngine;

        // Constructor.
        public RazorViewRenderer(
            IActionContextAccessor actionContextAccessor,
            ITempDataProvider tempDataProvider,
            IRazorViewEngine viewEngine)
        {
            this.actionContextAccessor = actionContextAccessor;
            this.tempDataProvider = tempDataProvider;
            this.viewEngine = viewEngine;
        }

        // Methods.
        public async Task<string> RenderViewToStringAsync<TModel>(string viewName, TModel model)
        {
            var actionContext = actionContextAccessor.ActionContext;
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
                new[] { $"Unable to find view '{viewName}'. The following locations were searched:" }.Concat(searchedLocations)); ;

            throw new InvalidOperationException(errorMessage);
        }
    }
}
