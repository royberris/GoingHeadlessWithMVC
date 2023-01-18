using Application.Models.Abstractions;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Application.Common
{
    public interface IContentResolver
    {
        public ContentWrapper Resolve(IPublishedContent content);
    }
}
