using BaseFramework.Repository;
using CommentManager.Domain.ReplayCommentAgg;

namespace CommentManager.Infrastructure.EfCore.Repository;

public class ProductReplayCommentRepository : BaseCommentRepository<long, ProductReplayComment>, IProductReplayCommentRepository
{
    public ProductReplayCommentRepository(CommentManagerEFCoreDbContext context) : base(context)
    {
    }
}