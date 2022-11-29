using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etherna.ACR.Middlewares.PrintConfigurationPage.Views
{
    public class PrintConfigurationPageModel
    {
        public PrintConfigurationPageModel(
            IConfiguration configuration,
            PrintConfigurationPageOptions options)
        {
            if (options is null)
                throw new ArgumentNullException(nameof(options));

            Configuration = configuration;
            Title = options.PageTitle;
        }

        public IConfiguration Configuration { get; }
        public string Title { get; }
    }
}
