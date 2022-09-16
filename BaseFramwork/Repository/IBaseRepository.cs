using System.Linq.Expressions;

namespace BaseFramwork.Repository;

public interface IBaseRepository<TKeyType, T> where T : class
{
    void Create(T entity);
    T? GetBy(TKeyType id);
    List<T> GetList();
    bool Exist(Expression<Func<T, bool>> expression);
    void UpdateEntity(T entity);
}
