using BaseFramework.Repository;

namespace ShopManagement.Domain.ProductAgg;

public interface IProductRepository : IBaseRepository<long, Product>
{
}