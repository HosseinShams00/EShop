namespace BaseFramwork.Domain;

public class ProductCategoryBase
{
    public long Id { get; private set; }
    public DateTime CreationTime { get; private set; }

    public ProductCategoryBase()
    {
        CreationTime = DateTime.Now;
    }
}