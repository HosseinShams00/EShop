using BaseFramework.Repository;
using SecondaryDB.Domain.ReplayCommentQueryAgg;

namespace SecondaryDB.Infrastructure.EFCore.Repository;

public class ProductReplayCommentQueryRepository : BaseCommentRepository<long, ProductReplayCommentQuery>, IProductReplayCommentQueryRepository
{
    public ProductReplayCommentQueryRepository(SecondaryDBEfCoreContext context) : base(context)
    {
    }
}