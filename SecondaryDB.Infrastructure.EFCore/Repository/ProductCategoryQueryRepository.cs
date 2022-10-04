using BaseFramework.Repository;
using SecondaryDB.Domain.ProductCategoryQueryAgg;

namespace SecondaryDB.Infrastructure.EFCore.Repository;

public class ProductCategoryQueryRepository : BaseQueryRepository<long, ProductCategoryQuery>, IProductCategoryQueryRepository
{
    public ProductCategoryQueryRepository(SecondaryDBEfCoreContext context) : base(context)
    {
    }
}
