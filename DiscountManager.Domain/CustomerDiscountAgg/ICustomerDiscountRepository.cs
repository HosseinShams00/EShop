using BaseFramwork.Repository;
using DiscountManager.Application.Contracts.CustommerDiscountAgg;
using DiscountManager.Application.Contracts.CustommerDiscountAgg.Command;
using System.Linq.Expressions;

namespace DiscountManager.Domain.CustomerDiscountAgg;

public interface ICustomerDiscountRepository : IBaseRepository<long , CustomerDiscount>
{
}
