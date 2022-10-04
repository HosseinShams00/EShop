using SecondaryDB.Domain.CustomerDiscountQueryAgg;
using SecondaryDB.Domain.InventoryQueryAgg;
using SecondaryDB.Domain.ProductCategoryQueryAgg;
using SecondaryDB.Domain.ProductCommentQueryAgg;
using SecondaryDB.Domain.ProductPictureQueryAgg;
using ShopManagement.Domain.ProductAgg;

namespace SecondaryDB.Domain.ProductQueryAgg;

public class ProductQuery : IProduct
{
    public long Id { get; set; }
    public DateTime CreationTime { get; set; }
    public bool IsRemoved { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ShortDescription { get; set; }
    public string Picture { get; set; }
    public string PictureAlt { get; set; }
    public string PictureTitle { get; set; }
    public string Keywords { get; set; }
    public string MetaDescription { get; set; }
    public string Slug { get; set; }
    public long ProductCategoryId { get; set; }
    public long? CustomerDiscountId { get; set; }

    public ProductCategoryQuery? ProductCategoryQuery { get; set; }
    public InventoryQuery? InventoryQuery { get; set; }
    public CustomerDiscountQuery? CustomerDiscountQuery { get; set; }
    public List<ProductPictureQuery> ProductPictureQueries { get; set; } = new();
    public List<ProductCommentQuery> ProductCommentQueries { get; set; } = new();

}