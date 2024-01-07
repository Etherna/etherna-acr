using Microsoft.AspNetCore.Http;
using System;

namespace Etherna.ACR.Middlewares.DebugPages.Views
{
    public class RequestPageModel
    {
        // Constructor.
        public RequestPageModel(HttpRequest request, DebugPagesOptions options)
        {
            ArgumentNullException.ThrowIfNull(options, nameof(options));

            Request = request;
            Title = options.RequestPageTitle;
        }

        // Properties.
        public HttpRequest Request { get; }
        public string Title { get; }
    }
}
