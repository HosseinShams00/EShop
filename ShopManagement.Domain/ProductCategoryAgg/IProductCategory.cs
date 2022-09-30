using BaseFramework.Domain;
using ShopManagement.Domain.ProductAgg;

namespace ShopManagement.Domain.ProductCategoryAgg;

public interface IProductCategory : IBaseDomain
{
    public string Name { get; }
    public string Description { get; }
    public string Picture { get; }
    public string PictureAlt { get; }
    public string PictureTitle { get; }
    public string Keywords { get; }
    public string MetaDescription { get; }
    public string Slug { get; }
    public IReadOnlyList<Product> Products { get; }
}