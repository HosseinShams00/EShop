using System.Linq.Expressions;

namespace EShopQuery.EfCore.Repository.BaseRepository;

public class BaseQueryRepository<TKeyType, T> : IBaseQueryRepository<TKeyType, T> where T : class
{
    private readonly EShopQueryEfCoreContext _context;

    public BaseQueryRepository(EShopQueryEfCoreContext context)
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