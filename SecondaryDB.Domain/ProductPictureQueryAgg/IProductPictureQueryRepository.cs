using BaseFramework.Repository;

namespace SecondaryDB.Domain.ProductPictureQueryAgg;

public interface IProductPictureQueryRepository : IBaseQueryRepository<long, ProductPictureQuery>
{
}
