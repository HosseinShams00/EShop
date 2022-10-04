using BaseFramework.Repository;

namespace SecondaryDB.Domain.ProductCategoryQueryAgg;

public interface IProductCategoryQueryRepository : IBaseQueryRepository<long, ProductCategoryQuery>
{
}
