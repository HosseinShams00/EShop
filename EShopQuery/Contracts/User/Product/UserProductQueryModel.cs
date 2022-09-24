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
    public int IntPrice { get; set; }
    public string Price { get; set; }
    public string PriceWithDiscount { get; set; }
    public bool IsInStock { get; set; }
    public bool HasDiscount { get; set; }
    public int DiscountRate { get; set; }
    public DateTime DiscountExpireDate { get; set; }  

}