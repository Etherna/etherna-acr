using System;
using System.Collections.Generic;

namespace Etherna.SSL.Pages.SharedModels
{
    public class PageSelectorModel
    {
        /// <summary>
        /// Constructor for PageSelector partial view Model
        /// </summary>
        /// <param name="currentPage">Current page, starting from 1</param>
        /// <param name="maxPage">Total page count</param>
        /// <param name="pageParamName">Name of page query parameter</param>
        /// <param name="routeData">Additional data to route</param>
        public PageSelectorModel(
            int currentPage,
            int maxPage,
            string pageParamName = "p",
            Dictionary<string, string>? routeData = null)
        {
            if (currentPage < 1)
                throw new ArgumentOutOfRangeException(nameof(currentPage), "Value can't be less than 1");
            if (maxPage < 1)
                throw new ArgumentOutOfRangeException(nameof(maxPage), "Value can't be less than 1");

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
