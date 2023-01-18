using Application.Models.Abstractions;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Application.MappingStrategies
{
    public interface IMappingStrategy<T>
        where T : IPublishedElement
    {
        public IContentModel Map(T content);
    }
}
