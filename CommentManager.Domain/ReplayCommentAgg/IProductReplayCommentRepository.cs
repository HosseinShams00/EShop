using BaseFramework.Repository;

namespace CommentManager.Domain.ReplayCommentAgg;

public interface IProductReplayCommentRepository : IBaseCommentRepository<long, ProductReplayComment>
{

}