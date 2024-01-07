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
            ArgumentNullException.ThrowIfNull(options, nameof(options));

            Configuration = configuration;
            Title = options.ConfigurationPageTitle;
        }

        // Properties.
        public IConfiguration Configuration { get; }
        public string Title { get; }
    }
}
