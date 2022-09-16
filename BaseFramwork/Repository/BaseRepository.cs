using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BaseFramwork.Repository;

public class BaseRepository<TKeyType, T> : IBaseRepository<TKeyType, T> where T : class
{
    private readonly DbContext Context;

    public BaseRepository(DbContext context)
    {
        Context = context;
    }

    public void Create(T entity)
    {
        Context.Add<T>(entity);
        UpdateEntity(entity);
    }

    public bool Exist(Expression<Func<T, bool>> expression)
    {
        return Context.Set<T>().AsNoTracking().Any(expression);
    }

    public T? GetBy(TKeyType id)
    {
        return Context.Set<T>().Find(id);
    }

    public List<T> GetList()
    {
        return Context.Set<T>().AsNoTracking().ToList();
    }

    public void UpdateEntity(T entity)
    {
        Context.SaveChanges();
    }

}
