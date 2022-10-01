using System.Linq.Expressions;

namespace EShopQuery.EfCore.Repository;

public class EShopRepository : IEShopRepository
{
    private readonly EShopQueryEfCoreContext _context;

    public EShopRepository(EShopQueryEfCoreContext context)
    {
        _context = context;
    }
    public void Create<T>(T entity) where T : class
    {
        _context.Add(entity);
        _context.SaveChanges();
    }

    public void Update<T>(T entity) where T : class
    {
        _context.SaveChanges();
    }

    public TEntity? Get<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : class
    {
        return _context.Set<TEntity>().Find(expression);
    }
}