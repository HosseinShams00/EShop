using BaseFramework.Repository;

namespace SecondaryDB.Domain;

public interface IProductCategoryQueryRepository : IBaseQueryRepository<long , ProductCategoryQuery>
{
}
