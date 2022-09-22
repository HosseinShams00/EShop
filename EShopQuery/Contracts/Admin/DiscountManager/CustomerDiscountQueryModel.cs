namespace EShopQuery.Contracts.Admin.DiscountManager;

public class CustomerDiscountQueryModel
{
    public long Id { get; set; }
    public string Title { get; set; }
    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
    public DateTime CreationDateTime { get; set; }
    public bool IsRemoved { get; set; }
    public int DiscountPercent { get; set; }
}
