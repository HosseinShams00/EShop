using System.Linq.Expressions;

namespace BaseFramework.Repository;

public interface IBaseAccountRepository<TKeyType, T> where T : class
{
    void Create(T entity);
    T? GetBy(TKeyType id);
    bool Exist(Expression<Func<T, bool>> expression);
    void UpdateEntity(T entity);
}