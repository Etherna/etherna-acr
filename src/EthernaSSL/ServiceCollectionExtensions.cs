using Etherna.SSL.Services;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Etherna.SSL
{
    public static class ServiceCollectionExtensions
    {
        public static void AddEthernaServicesSharedLibrary(this IServiceCollection services)
        {
            // Register dependencies.
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

            // Register services.
            services.AddScoped<IEmailSender, EmailSender>();
            services.AddScoped<IRazorViewRenderer, RazorViewRenderer>();
        }
    }
}
