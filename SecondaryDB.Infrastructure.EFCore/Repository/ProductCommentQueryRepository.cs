using BaseFramework.Repository;
using SecondaryDB.Domain.ProductCommentQueryAgg;

namespace SecondaryDB.Infrastructure.EFCore.Repository;

public class ProductCommentQueryRepository : BaseCommentRepository<long, ProductCommentQuery>, IProductCommentQueryRepository
{
    public ProductCommentQueryRepository(SecondaryDBEfCoreContext context) : base(context)
    {
    }
}