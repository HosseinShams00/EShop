using BaseFramework.Repository;

namespace SecondaryDB.Domain.ReplayCommentQueryAgg;

public interface IProductReplayCommentQueryRepository : IBaseCommentRepository<long, ProductReplayCommentQuery>
{

}