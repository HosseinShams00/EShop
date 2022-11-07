using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace BaseFramework.Repository;

public class BaseAccountRepository<TKeyType, T> : IBaseAccountRepository<TKeyType, T> where T : class
{
    private readonly DbContext _context;

    public BaseAccountRepository(DbContext context)
    {
        _context = context;
    }

    public void Create(T entity)
    {
        _context.Add<T>(entity);
        UpdateEntity(entity);
    }

    public bool Exist(Expression<Func<T, bool>> expression)
    {
        return _context.Set<T>().AsNoTracking().Any(expression);
    }

    public T? GetBy(TKeyType id)
    {
        return _context.Set<T>().Find(id);
    }
    
    public void UpdateEntity(T entity)
    {
        _context.SaveChanges();
    }

}