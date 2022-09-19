using BaseFramwork.Repository;
using DiscountManager.Application.Contracts.CustommerDiscountAgg;
using DiscountManager.Application.Contracts.CustommerDiscountAgg.Command;
using DiscountManager.Domain.CustomerDiscountAgg;
using Microsoft.EntityFrameworkCore;

namespace DiscountManager.Infrastructure.EFCore.Repository;

public class CustomerDiscountRepository : BaseRepository<long, CustomerDiscount>, ICustomerDiscountRepository
{
    public CustomerDiscountRepository(DiscountManagerEFCoreDbContext context) : base(context)
    {
    }
}
