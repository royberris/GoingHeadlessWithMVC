using Presentation.Controllers;
using Umbraco.Cms.Web.Website.Controllers;

namespace Presentation
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddPresentationServices(this IServiceCollection services)
        {
            services.Configure<UmbracoRenderingDefaultsOptions>(c =>
            {
                c.DefaultControllerType = typeof(DefaultRenderController);
            });
            
            return services;
        }
    }
}
