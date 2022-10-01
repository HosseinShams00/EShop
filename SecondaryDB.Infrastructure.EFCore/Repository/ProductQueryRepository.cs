using BaseFramework.Repository;
using SecondaryDB.Domain;

namespace SecondaryDB.Infrastructure.EFCore.Repository;

public class ProductQueryRepository : BaseQueryRepository<long, ProductQuery> , IProductQueryRepository
{
    public ProductQueryRepository(SecondaryDBEfCoreContext context) : base(context)
    {
    }
}
