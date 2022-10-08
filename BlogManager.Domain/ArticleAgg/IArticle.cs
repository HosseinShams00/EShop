using BaseFramework.Domain.BaseDomainAgg;

namespace BlogManager.Domain.ArticleAgg;

public interface IArticle : IBaseDomain
{
    public string Title { get; }
    public string ShortDescription { get; }
    public string Description { get; }
    public string Picture { get; }
    public string PictureAlt { get; }
    public string PictureTitle { get; }
    public string Slug { get; }
    public string Keywords { get; }
    public string MetaDescription { get; }
    public long CategoryId { get; }
}