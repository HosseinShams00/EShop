using System.Linq.Expressions;

namespace EShopQuery.EfCore.Repository;

public interface IEShopRepository
{
    void Create<T>(T entity) where T : class;
    void Update<T>(T entity) where T : class;
    TEntity? Get<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : class;
}