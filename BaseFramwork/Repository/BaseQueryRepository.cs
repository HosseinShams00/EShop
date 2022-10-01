using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace BaseFramework.Repository;

public class BaseQueryRepository<TKeyType, T> : IBaseQueryRepository<TKeyType, T> where T : class
{
    private readonly DbContext _context;

    public BaseQueryRepository(DbContext context)
    {
        _context = context;
    }
    public void Create(T entity)
    {
        _context.Add(entity);
        _context.SaveChanges();
    }

    public T? Get(Expression<Func<T, bool>> expression)
    {
        return _context.Set<T>().Find(expression);
    }

    public void UpdateEntity(T entity)
    {
        _context.SaveChanges();
    }

    public void Delete(T entity)
    {
        _context.Remove(entity);
        _context.SaveChanges();
    }
}