using Application.Common;
using Application.MappingStrategies;
using CMS.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IContentResolver, ContentResolver>();

            // Register the mapping strategies
            services.AddScoped<IMappingStrategy<BlogPage>, BlogStrategy>();
            services.AddScoped<IMappingStrategy<NewsPage>, NewsStrategy>();

            return services;
        }
    }
}
