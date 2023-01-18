using Application.Models.Abstractions;
using Application.Models.Pages;
using CMS.Models;

namespace Application.MappingStrategies
{
    public class BlogStrategy : IMappingStrategy<BlogPage>
    {
        public IContentModel Map(BlogPage content)
        {
            return new ContentDetailPage
            {
                Title = content.Title ?? string.Empty,
                IntroText = content.IntroText,
                Category = "Blog",
                PublishDate = content.UpdateDate
            };
        }
    }
}
