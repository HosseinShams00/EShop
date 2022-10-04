using BaseFramework.Repository;
using SecondaryDB.Domain.ProductQueryAgg;

namespace SecondaryDB.Infrastructure.EFCore.Repository;

public class ProductQueryRepository : BaseQueryRepository<long, ProductQuery>, IProductQueryRepository
{
    private readonly SecondaryDBEfCoreContext _context;

    public ProductQueryRepository(SecondaryDBEfCoreContext context) : base(context)
    {
        _context = context;
    }

    public void RemoveDiscount(long productId)
    {
        var productQuery = _context.ProductQueries.Where(x => x.Id == productId).FirstOrDefault();
        if (productQuery != null)
        {
            productQuery.CustomerDiscountId = null;
            UpdateEntity(productQuery);
        }
    }

    public void AddDiscount(long productId, long discountId)
    {
        var productQuery = _context.ProductQueries.Where(x => x.Id == productId).FirstOrDefault();
        if (productQuery != null)
        {
            productQuery.CustomerDiscountId = discountId;
            UpdateEntity(productQuery);
        }
    }

    public void EditDiscount(long productId, long discountId)
    {
        var productQuery = _context.ProductQueries.Where(x => x.Id == productId).FirstOrDefault();
        if (productQuery != null)
        {
            productQuery.CustomerDiscountId = discountId;
            UpdateEntity(productQuery);
        }
    }
}
