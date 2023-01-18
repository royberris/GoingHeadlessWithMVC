using Application.Models.Abstractions;

namespace Application.Models.Pages
{
    public class ContentDetailPage : IContentModel
    {
        required public string Title { get; set; }

        public string? IntroText { get; set; }

        public DateTime PublishDate { get; set; }

        required public string Category { get; set; }
    }
}
