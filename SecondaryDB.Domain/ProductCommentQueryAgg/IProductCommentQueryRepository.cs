using BaseFramework.Repository;

namespace SecondaryDB.Domain.ProductCommentQueryAgg;

public interface IProductCommentQueryRepository : IBaseCommentRepository<long, ProductCommentQuery>
{

}