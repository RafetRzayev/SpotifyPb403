using Spotify.Domain.Entities;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;

namespace Spotify.Domain.Interfaces;

public interface IRepository<T> where T : Entity
{
    T GetById(int id);
    T Get(Expression<Func<T, bool>> predicate, bool asNoTracking = false,
        Func<IQueryable<T>,IIncludableQueryable<T, object>>? include = null);

    List<T> GetAll(Expression<Func<T, bool>>? predicate = null, bool asNoTracking = false, 
        Func<IQueryable<T>,IIncludableQueryable<T, object>>? include = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null);

    T Add(T entity);
    T Update(T entity);
    T Delete(T entity);
}
