using System;
using System.Collections.Generic;

namespace Etherna.RCL.Pages.SharedModels
{
    public class PageSelectorModel
    {
        public PageSelectorModel(
            int currentPage,
            int maxPage,
            string pageParamName = "p",
            Dictionary<string, string>? routeData = null)
        {
            if (currentPage < 0)
                throw new ArgumentOutOfRangeException(nameof(currentPage), "Value can't be negative");
            if (maxPage < 0)
                throw new ArgumentOutOfRangeException(nameof(maxPage), "Value can't be negative");

            CurrentPage = currentPage;
            MaxPage = maxPage;
            PageParamName = pageParamName ?? throw new ArgumentNullException(nameof(pageParamName));
            RouteData = routeData ?? new Dictionary<string, string>();
        }

        public int CurrentPage { get; }
        public int MaxPage { get; }
        public string PageParamName { get; }
        public IDictionary<string, string> RouteData { get; }
    }
}
