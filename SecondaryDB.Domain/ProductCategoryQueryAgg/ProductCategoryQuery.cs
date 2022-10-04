using SecondaryDB.Domain.ProductQueryAgg;
using ShopManagement.Domain.ProductCategoryAgg;

namespace SecondaryDB.Domain.ProductCategoryQueryAgg;

public class ProductCategoryQuery : IProductCategory
{
    public long Id { get; set; }
    public DateTime CreationTime { get; set; }
    public bool IsRemoved { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Picture { get; set; }
    public string PictureAlt { get; set; }
    public string PictureTitle { get; set; }
    public string Keywords { get; set; }
    public string MetaDescription { get; set; }
    public string Slug { get; set; }

    public List<ProductQuery> Products { get; set; } = new();
}