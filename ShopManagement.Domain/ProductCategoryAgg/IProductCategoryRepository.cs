using BaseFramwork.Repository;


namespace ShopManagement.Domain.ProductCategoryAgg;

public interface IProductCategoryRepository : IBaseRepository<long , ProductCategory>
{
}
