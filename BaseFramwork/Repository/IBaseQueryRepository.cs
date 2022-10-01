using System.Linq.Expressions;

namespace BaseFramework.Repository;

public interface IBaseQueryRepository<TKeyType, T> where T : class
{
    void Create(T entity);
    T? Get(Expression<Func<T, bool>> expression);
    void UpdateEntity(T entity);
    void Delete(T entity);
}