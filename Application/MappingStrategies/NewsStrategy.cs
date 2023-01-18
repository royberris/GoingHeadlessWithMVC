using Application.Models.Abstractions;
using Application.Models.Pages;
using CMS.Models;
using Umbraco.Cms.Core.Dictionary;

namespace Application.MappingStrategies
{
    public class NewsStrategy : IMappingStrategy<NewsPage>
    {
        private readonly ICultureDictionary _dictioniary;

        public NewsStrategy(ICultureDictionaryFactory dictionairyFactory)
        {
            _dictioniary = dictionairyFactory.CreateDictionary();
        }

        public IContentModel Map(NewsPage content)
        {
            return new ContentDetailPage
            {
                Title = content.Title ?? string.Empty,
                IntroText = content.HeaderIntroText,
                Category = _dictioniary["Category.News"] ?? "Nieuws",
                PublishDate = content.UpdateDate
            };
        }
    }
}
