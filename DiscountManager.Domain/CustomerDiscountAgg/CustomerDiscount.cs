using BaseFramwork.Domain;
using DiscountManager.Domain.ProductCustomerDiscountAgg;

namespace DiscountManager.Domain.CustomerDiscountAgg;

public class CustomerDiscount : BaseDomain
{
    public string Title { get; private set; }
    public string? Description { get; private set; }
    public DateTime StartDateTime { get; private set; }
    public DateTime EndDateTime { get; private set; }
    public int DiscountPercent { get; private set; }
    public IReadOnlyCollection<ProductCustomerDiscount> Products { get; private set; }

    protected CustomerDiscount()
    {
        Products = new List<ProductCustomerDiscount>();
    }

    public CustomerDiscount(string title, string? description,
        DateTime startDateTime, DateTime endDateTime,
        int discountPercent, ICustomerDiscountValidator validator)
    {
        validator.CheckTitleExist(title);

        Title = title;
        Description = description;

        validator.CheckDateTime(startDateTime, endDateTime);

        StartDateTime = startDateTime;
        EndDateTime = endDateTime;

        validator.CheckDiscountPercent(discountPercent);
        DiscountPercent = discountPercent;
    }

    public void Edit(string title, string? description,
        DateTime startDateTime, DateTime endDateTime,
        int discountPercent, ICustomerDiscountValidator validator)
    {
        validator.CheckTitleExist(title , this.Id);

        Title = title;
        Description = description;

        validator.CheckDateTime(startDateTime, endDateTime);

        StartDateTime = startDateTime;
        EndDateTime = endDateTime;

        validator.CheckDiscountPercent(discountPercent);
        DiscountPercent = discountPercent;
    }
}
