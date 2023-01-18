using Application.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using System.Text.Json;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;

namespace Presentation.Controllers
{
    public class DefaultRenderController : RenderController
    {
        private readonly IContentResolver _contentResolver;

        public DefaultRenderController(ILogger<RenderController> logger, ICompositeViewEngine compositeViewEngine, IUmbracoContextAccessor umbracoContextAccessor, IContentResolver contentResolver)
            : base(logger, compositeViewEngine, umbracoContextAccessor)
        {
            _contentResolver = contentResolver;
        }

        public override IActionResult Index()
        {
            var publishedContent = UmbracoContext.PublishedRequest?.PublishedContent;

            if (publishedContent is null)
            {
                return NotFound();
            }

            var result = _contentResolver.Resolve(publishedContent);

            if (Request.Query["json"] == "true")
            {
                var json = JsonSerializer.Serialize(result, new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Converters =
                    {
                        new ContentModelConverter()
                    }
                });

                return Ok(json);
            }

            return View(result.Template, result.ContentModel);
        }
    }
}
