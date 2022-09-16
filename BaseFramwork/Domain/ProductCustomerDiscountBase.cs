namespace BaseFramwork.Domain;

public class ProductCustomerDiscountBase
{
    public long Id { get; private set; }
    public DateTime CreationTime { get; private set; }

    public ProductCustomerDiscountBase()
    {
        CreationTime = DateTime.Now;
    }

}