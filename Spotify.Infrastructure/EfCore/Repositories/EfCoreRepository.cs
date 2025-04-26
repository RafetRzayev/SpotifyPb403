using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Spotify.Domain.Entities;
using Spotify.Domain.Interfaces;
using Spotify.Infrastructure.EfCore.DataContext;
using System.Linq.Expressions;

namespace Spotify.Infrastructure.EfCore.Repositories;

public class EfCoreRepository<T> : IRepository<T> where T : Entity
{
    private readonly AppDbContext _context;

    public EfCoreRepository()
    {
        _context = new AppDbContext();
    }

    public virtual T Add(T entity)
    {
        var added = _context.Set<T>().Add(entity);
        _context.SaveChanges();

        return added.Entity;
    }

    public virtual T Delete(T entity)
    {
        var deleted = _context.Set<T>().Remove(entity);
        _context.SaveChanges();

        return deleted.Entity;
    }

    public T Get(Expression<Func<T, bool>> predicate, bool asNoTracking = false, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null)
    {
        IQueryable<T> query = _context.Set<T>();

        query = query.Where(predicate);

        if (!asNoTracking)
            query = query.AsNoTracking();

        if (include != null)
            query = include.Invoke(query);

        return query.FirstOrDefault() ?? throw new InvalidOperationException("Entity not found");
    }

    public virtual List<T> GetAll(Expression<Func<T, bool>>? predicate = null, bool asNoTracking = false, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null)
    {
        IQueryable<T> query = _context.Set<T>();

        if (predicate != null)
            query = query.Where(predicate);

        if (include != null)
            query = include.Invoke(query);

        if (orderBy != null)
            query = orderBy.Invoke(query);

        if (!asNoTracking)
            query = query.AsNoTracking();

        return query.ToList();
    }

    public virtual T GetById(int id)
    {
        return _context.Set<T>().AsNoTracking().SingleOrDefault(x => x.Id == id) ?? throw new InvalidOperationException("Entity not found");
    }

    public virtual T Update(T entity)
    {
        var updated = _context.Set<T>().Update(entity);
        _context.SaveChanges();

        return updated.Entity;
    }
}
