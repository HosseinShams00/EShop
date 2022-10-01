using DiscountManager.Domain.CustomerDiscountAgg;

namespace EShopQuery.Contracts.DbContract;

public class CustomerDiscountQuery : ICustomerDiscount
{
    public long Id { get; set; }
    public DateTime CreationTime { get; set; }
    public bool IsRemoved { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
    public int DiscountPercent { get; set; }

    public List<ProductQuery> ProductQueries { get; set; } = new();

}