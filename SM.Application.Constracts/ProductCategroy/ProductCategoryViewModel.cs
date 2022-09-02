namespace ShopManagement.Application.Constracts.ProductCategroy;

public class ProductCategoryViewModel
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Picture { get; set; }
    public string CreationTime { get; set; }
    public long ProductsCount { get; set; }
    public bool IsRemoved { get; set; }
}