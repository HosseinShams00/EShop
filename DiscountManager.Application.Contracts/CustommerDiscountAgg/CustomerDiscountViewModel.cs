namespace DiscountManager.Application.Contracts.CustommerDiscountAgg;

public class CustomerDiscountViewModel
{
    public long Id { get; set; }
    public string Title { get; set; }
    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
    public DateTime CreationDateTime { get; set; }
    public bool IsRemoved { get; set; }
    public int DiscountPercent { get; set; }
}
