using BaseFramework.Repository;
using CommentManager.Domain.ProductCommentAgg;

namespace CommentManager.Infrastructure.EfCore.Repository;

public class ProductCommentRepository : BaseCommentRepository<long, ProductComment>, IProductCommentRepository
{
    public ProductCommentRepository(CommentManagerEFCoreDbContext context) : base(context)
    {
    }
}