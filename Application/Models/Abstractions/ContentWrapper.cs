namespace Application.Models.Abstractions
{
    public class ContentWrapper
    {
        required public IContentModel ContentModel { get; set; }

        required public Guid Key { get; set; }

        required public string Template { get; set; }

        required public string Url { get; set; }
    }
}
