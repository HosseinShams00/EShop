using BaseFramwork.Repository;
using DiscountManager.Domain.CustomerDiscountAgg;

namespace DiscountManager.Infrastructure.EFCore.Repository;

public class CustomerDiscountRepository : BaseRepository<long, CustomerDiscount>, ICustomerDiscountRepository
{
    public CustomerDiscountRepository(DiscountManagerEFCoreDbContext context) : base(context)
    {
    }
}
