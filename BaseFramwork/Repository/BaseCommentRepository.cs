using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace BaseFramework.Repository;

public class BaseCommentRepository<TKeyType, T> : IBaseCommentRepository<TKeyType, T> where T : class
{
    private readonly DbContext _context;

    public BaseCommentRepository(DbContext context)
    {
        _context = context;
    }
    public void Create(T entity)
    {
        _context.Add(entity);
        _context.SaveChanges();
    }

    public T? GetBy(TKeyType id)
    {
        return _context.Set<T>().Find(id);
    }

    public void UpdateEntity(T entity)
    {
        _context.SaveChanges();
    }

    public bool Exist(Expression<Func<T, bool>> expression)
    {
        return _context.Set<T>().Any(expression);
    }
}