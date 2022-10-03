using BaseFramework.Repository;

namespace CommentManager.Domain.ProductCommentAgg;

public interface IProductCommentRepository : IBaseCommentRepository<long, ProductComment>
{

}