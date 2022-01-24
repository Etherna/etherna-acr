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

using System.Collections.Generic;

namespace Etherna.ACR.Pages.SharedModels
{
    public class SearchModel
    {
        public SearchModel(
            string? query,
            string? razorPage = default,
            string? razorPageHandler = default,
            Dictionary<string, string>? routeData = null,
            string searchParamName = "q")
        {
            Query = query ?? "";
            RazorPage = razorPage;
            RazorPageHandler = razorPageHandler;
            RouteData = routeData ?? new Dictionary<string, string>();
            SearchParamName = searchParamName;
        }

        public string Query { get; }
        public string? RazorPage { get; }
        public string? RazorPageHandler { get; }
        public IDictionary<string, string> RouteData { get; }
        public string SearchParamName { get; }
    }
}
