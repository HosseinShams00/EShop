﻿using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BaseFramework.Repository;

public class BaseRepository<TKeyType, T> : IBaseRepository<TKeyType, T> where T : class
{
    private readonly DbContext _context;

    public BaseRepository(DbContext context)
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

    public List<T> GetList()
    {
        return _context.Set<T>().AsNoTracking().ToList();
    }

    public void UpdateEntity(T entity)
    {
        _context.SaveChanges();
    }

}