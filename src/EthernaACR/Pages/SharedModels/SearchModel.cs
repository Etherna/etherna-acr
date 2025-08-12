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

using System.Collections.Generic;

namespace Etherna.ACR.Pages.SharedModels
{
    public class SearchModel(
        string? query,
        string? razorPage = null,
        string? razorPageHandler = null,
        Dictionary<string, string>? routeData = null,
        string searchParamName = "q")
    {
        public string Query { get; } = query ?? "";
        public string? RazorPage { get; } = razorPage;
        public string? RazorPageHandler { get; } = razorPageHandler;
        public IDictionary<string, string> RouteData { get; } = routeData ?? new Dictionary<string, string>();
        public string SearchParamName { get; } = searchParamName;
    }
}
