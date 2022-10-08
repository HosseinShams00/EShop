using BaseFramework.Domain.BaseDomainAgg;
using BlogManager.Domain.ArticleAgg;

namespace BlogManager.Domain.ArticleCategoryAgg;

public class ArticleCategory : BaseDomain, IArticleCategory
{
    public string Name { get; private set; }
    public string Picture { get; private set; }
    public string PictureAlt { get; private set; }
    public string PictureTitle { get; private set; }
    public string Description { get; private set; }
    public int ShowOrder { get; private set; }
    public string Slug { get; private set; }
    public string Keywords { get; private set; }
    public string MetaDescription { get; private set; }
    public IReadOnlyCollection<Article> Articles { get; private set; }

    protected ArticleCategory()
    {

    }

    public ArticleCategory(string name, string picture,
        string pictureAlt, string pictureTitle,
        string description, int showOrder,
        string slug, string keywords,
        string metaDescription)
    {
        Name = name;
        Picture = picture;
        PictureAlt = pictureAlt;
        PictureTitle = pictureTitle;
        Description = description;
        ShowOrder = showOrder;
        Slug = slug;
        Keywords = keywords;
        MetaDescription = metaDescription;
    }

    public void Edit(string name, string picture,
        string pictureAlt, string pictureTitle,
        string description, int showOrder,
        string slug, string keywords,
        string metaDescription)
    {
        Name = name;
        Picture = picture;
        PictureAlt = pictureAlt;
        PictureTitle = pictureTitle;
        Description = description;
        ShowOrder = showOrder;
        Slug = slug;
        Keywords = keywords;
        MetaDescription = metaDescription;
    }
}