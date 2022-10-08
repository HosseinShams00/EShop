using BaseFramework.Domain.BaseDomainAgg;

namespace BlogManager.Domain.ArticleCategoryAgg;

public interface IArticleCategory : IBaseDomain
{
    public string Name { get; }
    public string Picture { get; }
    public string PictureAlt { get; }
    public string PictureTitle { get; }
    public string Description { get; }
    public int ShowOrder { get; }
    public string Slug { get; }
    public string Keywords { get; }
    public string MetaDescription { get; }
    //public string CanonicalAddress { get; }
}