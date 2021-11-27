using Etherna.RCL.Services;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static void AddEthernaRCL(this IServiceCollection services)
        {
            // Register dependencies.
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

            // Register services.
            services.AddScoped<IEmailSender, EmailSender>();
            services.AddScoped<IRazorViewRenderer, RazorViewRenderer>();
        }
    }
}
