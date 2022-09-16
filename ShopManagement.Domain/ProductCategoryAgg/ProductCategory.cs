using BaseFramwork.Domain;
using ShopManagement.Domain.ProductAgg;

namespace ShopManagement.Domain.ProductCategoryAgg;

public class ProductCategory : BaseDomain
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public string Picture { get; private set; }
    public string PictureAlt { get; private set; }
    public string PictureTitle { get; private set; }
    public string Keywords { get; private set; }
    public string MetaDescription { get; private set; }
    public string Slug { get; private set; }
    public IReadOnlyList<Product> Products { get; private set; }

    protected ProductCategory()
    {
        Products = new List<Product>();
    }

    public ProductCategory(string name, string description, string picture,
        string pictureAlt, string pictureTitle,
        string keywords, string metaDescription,
        string slug, IProductCategoryValidator validator)
    {
        validator.CheckCategoryNameExist(name);
        Name = name;
        Description = description;
        Picture = picture;
        PictureAlt = pictureAlt;
        PictureTitle = pictureTitle;
        Keywords = keywords;
        MetaDescription = metaDescription;
        Slug = slug;
    }

    public void Edit(string name, string description, string picture,
        string pictureAlt, string pictureTitle,
        string keywords, string metaDescription,
        string slug, IProductCategoryValidator validator)
    {
        validator.CheckCategoryNameExistWithId(name, Id);
        Name = name;
        Description = description;
        Picture = picture;
        PictureAlt = pictureAlt;
        PictureTitle = pictureTitle;
        Keywords = keywords;
        MetaDescription = metaDescription;
        Slug = slug;
    }
}