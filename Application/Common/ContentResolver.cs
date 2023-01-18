using Application.MappingStrategies;
using Application.Models.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Extensions;

namespace Application.Common
{
    public class ContentResolver : IContentResolver
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IFileService _fileService;
        private readonly IPublishedUrlProvider _publishedUrlProvider;

        public ContentResolver(
            IServiceProvider serviceProvider,
            IFileService fileService,
            IPublishedUrlProvider publishedUrlProvider)
        {
            _serviceProvider = serviceProvider;
            _fileService = fileService;
            _publishedUrlProvider = publishedUrlProvider;
        }

        public ContentWrapper Resolve(IPublishedContent content)
        {
            var contentModel = ResolveContentModel(content);
            var template = content.GetTemplateAlias(_fileService);

            return new ContentWrapper
            {
                ContentModel = contentModel,
                Key = content.Key,
                Template = template,
                Url = _publishedUrlProvider.GetUrl(content, mode: UrlMode.Absolute)
            };
        }

        private IContentModel ResolveContentModel(object content)
        {
            if (content is not IPublishedElement)
            {
                throw new ArgumentException(
                    $"Cannot parse content to {nameof(IPublishedElement)}");
            }

            var contentType = content.GetType();
            var strategyInterfaceType = typeof(IMappingStrategy<>).MakeGenericType(contentType);

            var strategy = _serviceProvider.GetRequiredService(strategyInterfaceType);

            if (strategy is null)
            {
                throw new InvalidOperationException(
                    $"Cannot get mapping strategy for content type {contentType.Name}");
            }

            if (strategy?.GetType()?
                .GetMethod(nameof(IMappingStrategy<IPublishedElement>.Map))?
                .Invoke(strategy, new[] { content }) is not IContentModel executedMethod)
            {
                throw new InvalidOperationException(
                    $"Cannot execute mapping strategy for content type {contentType.Name}");
            }

            return executedMethod;
        }
    }
}
