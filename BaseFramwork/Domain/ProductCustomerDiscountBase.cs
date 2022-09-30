namespace BaseFramework.Domain;

public class ProductCustomerDiscountBase : IProductCustomerDiscountBase
{
    public long Id { get; private set; }
    public DateTime CreationTime { get; private set; }

    public ProductCustomerDiscountBase()
    {
        CreationTime = DateTime.Now;
    }

}