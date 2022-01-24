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

using System;
using System.Collections.Generic;

namespace Etherna.ACR.Pages.SharedModels
{
    public class PageSelectorModel
    {
        /// <summary>
        /// Constructor for PageSelector partial view Model
        /// </summary>
        /// <param name="currentPage">Current page</param>
        /// <param name="maxPage">Total page count</param>
        /// <param name="firstPage">First page number. Usually it can be 0 or 1</param>
        /// <param name="pageParamName">Name of page query parameter</param>
        /// <param name="routeData">Additional data to route</param>
        public PageSelectorModel(
            int currentPage,
            int maxPage,
            int firstPage = 0,
            string pageParamName = "p",
            Dictionary<string, string>? routeData = null)
        {
            if (currentPage < firstPage)
                throw new ArgumentOutOfRangeException(nameof(currentPage), $"Value can't be less than {firstPage}");
            if (maxPage < firstPage)
                throw new ArgumentOutOfRangeException(nameof(maxPage), $"Value can't be less than {firstPage}");

            CurrentPage = currentPage;
            MaxPage = maxPage;
            FirstPage = firstPage;
            PageParamName = pageParamName ?? throw new ArgumentNullException(nameof(pageParamName));
            RouteData = routeData ?? new Dictionary<string, string>();
        }

        public int FirstPage { get; }
        public int CurrentPage { get; }
        public int MaxPage { get; }
        public string PageParamName { get; }
        public IDictionary<string, string> RouteData { get; }
    }
}
