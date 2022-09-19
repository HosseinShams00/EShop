using BaseFramwork.Application.Exceptions;
using BaseFramwork.Repository;
using DiscountManager.Domain.ProductCustomerDiscountAgg;
using Microsoft.EntityFrameworkCore;

namespace DiscountManager.Infrastructure.EFCore.Repository;

public class ProductCustomerDiscountRepository : BaseRepository<long, ProductCustomerDiscount>, IProductCustomerDiscountRepository
{
    private readonly DiscountManagerEFCoreDbContext Context;

    public ProductCustomerDiscountRepository(DiscountManagerEFCoreDbContext context) : base(context)
    {
        Context = context;
    }

    public long GetCustomerDiscountId(long productId)
    {
        var productCustomer = Context.ProductCustomerDiscounts.AsNoTracking().FirstOrDefault(x => x.ProductId == productId);
        if (productCustomer == null)
            return 0;

        return productCustomer.CustomerDiscountId;
    }

    public void RemoveBy(long productId)
    {
        var product = Context.ProductCustomerDiscounts.FirstOrDefault(x => x.ProductId == productId);

        if (product == null)
            throw new EntityNotFoundException();

        Context.ProductCustomerDiscounts.Remove(product);
        Context.SaveChanges();
    }

}