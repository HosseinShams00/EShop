using BaseFramework.Repository;

namespace SecondaryDB.Domain.ProductQueryAgg;

public interface IProductQueryRepository : IBaseQueryRepository<long, ProductQuery>
{
    void RemoveDiscount(long productId);
    void AddDiscount(long productId, long discountId);
    void EditDiscount(long productId, long discountId);
}