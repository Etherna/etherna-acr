using Microsoft.Extensions.Configuration;
using System;

namespace Etherna.ACR.Middlewares.DebugPages.Views
{
    public class ConfigurationPageModel
    {
        // Constructor.
        public ConfigurationPageModel(
            IConfiguration configuration,
            DebugPagesOptions options)
        {
            if (options is null)
                throw new ArgumentNullException(nameof(options));

            Configuration = configuration;
            Title = options.ConfigurationPageTitle;
        }

        // Properties.
        public IConfiguration Configuration { get; }
        public string Title { get; }
    }
}
