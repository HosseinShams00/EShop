using BaseFramework.Domain;

namespace ShopManagement.Domain.ProductAgg;

public interface IProduct : IBaseDomain
{
    public string Name { get; }
    public string Description { get; }
    public string ShortDescription { get; }
    public string Picture { get; }
    public string PictureAlt { get; }
    public string PictureTitle { get; }
    public string Keywords { get; }
    public string MetaDescription { get; }
    public string Slug { get; }
    public long ProductCategoryId { get; }
}