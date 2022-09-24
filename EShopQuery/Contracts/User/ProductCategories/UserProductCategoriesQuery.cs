using EShopQuery.Contracts.User.Product;

namespace EShopQuery.Contracts.User.ProductCategories;

public class UserProductCategoriesQuery
{
    public long Id { get; set; }    
    public string Name { get; set; }
    public string Picture { get; set; }
    public string PictureAlt { get; set; }
    public string PictureTitle { get; set; }
    public string Slug { get; set; }
    public string Description { get; set; }
    public List<UserProductQueryModel> ProductQueryModels { get; set; }  
}
