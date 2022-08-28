namespace ShopManagement.Application.Constracts.ProductCategroy.Command;

public class CreateProductCategory
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public string Picture { get; private set; }
    public string PictureAlt { get; private set; }
    public string PictureTitle { get; private set; }
    public string Keywords { get; private set; }
    public string MetaDescription { get; private set; }
    public string Slug { get; private set; }
}
