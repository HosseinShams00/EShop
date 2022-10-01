using BaseFramework.Repository;
using SecondaryDB.Domain;

namespace SecondaryDB.Infrastructure.EFCore.Repository;

public class ProductCategoryQueryRepository : BaseQueryRepository<long, ProductCategoryQuery>, IProductCategoryQueryRepository
{
    public ProductCategoryQueryRepository(SecondaryDBEfCoreContext context) : base(context)
    {
    }
}
