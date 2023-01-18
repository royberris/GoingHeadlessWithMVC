using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CMS
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddCmsServices(
            this IServiceCollection services,
            IConfiguration configuration,
            IHostEnvironment environment)
        {
            if (environment.IsEnvironment("test"))
            {
                // Do something
            }

            return services;
        }
    }
}
