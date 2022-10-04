using EShopQuery.Contracts.User.ProductComment;

namespace EShopQuery.Contracts.User.Product;

public class UserProductQueryModel
{
    public long Id { get; set; }
    public string Picture { get; set; }
    public string PictureAlt { get; set; }
    public string PictureTitle { get; set; }
    public string Name { get; set; }
    public string CategoryName { get; set; }
    public string Slug { get; set; }
    public int? IntPrice { get; set; }
    public string Price { get; set; }
    public string PriceWithDiscount { get; set; }
    public string Description { get; set; }
    public string Keywords { get; set; }
    public string MetaDescription { get; set; }
    public string ShortDescription { get; set; }
    public string CategorySlug { get; set; }
    public bool IsInStock { get; set; }
    public bool HasDiscount { get; set; }
    public int? DiscountRate { get; set; }
    public DateTime? DiscountExpireDate { get; set; }
    public List<UserProductCommentQueryModel> UserProductCommentQueryModels { get; set; } = new();
    public List<UserProductPictureQueryModel> UserProductPictureQueryModels { get; set; } = new();

}