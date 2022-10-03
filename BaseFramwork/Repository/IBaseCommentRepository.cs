using System.Linq.Expressions;

namespace BaseFramework.Repository;

public interface IBaseCommentRepository<TKeyType, T> where T : class
{
    void Create(T entity);
    T? GetBy(TKeyType id);
    void UpdateEntity(T entity);
    bool Exist(Expression<Func<T, bool>> expression);
}