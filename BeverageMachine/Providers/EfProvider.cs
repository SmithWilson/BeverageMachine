using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using BeverageMachine.Contracts;
using BeverageMachine.Entities;

using Microsoft.EntityFrameworkCore;

namespace BeverageMachine.Providers
{
  public class EfProvider<T> : IDataProvider<T> where T : class
  {
    private readonly BMContext _context;

    public EfProvider(BMContext context)
    {
      _context = context;
    }

    public void Add(T entity)
    {
      _context.Add(entity);
    }

    public async Task<T> GetAsync(
      Expression<Func<T, bool>> query,
      string[] includes = null)
    {
      IQueryable<T> baseQuery = IncludeProperties(includes, _context.Set<T>());
      return await baseQuery.FirstOrDefaultAsync(query);
    }

    public async Task<List<T>> GetListAsync(
      Expression<Func<T, bool>> query = null,
      string[] includes = null)
    {
      IQueryable<T> baseQuery = IncludeProperties(includes, _context.Set<T>());

      return query is null
        ? await baseQuery.ToListAsync()
        : await baseQuery.Where(query).ToListAsync();
    }

    public void Remove(T entity)
    {
      _context.Remove(entity);
    }

    public Task<int> SaveAsync()
    {
      return _context.SaveChangesAsync();
    }

    private static IQueryable<T> IncludeProperties(string[] navigations, IQueryable<T> baseQuery)
    {
      if (navigations != null
          && navigations.Length > 0)
      {
        baseQuery = navigations
            .Aggregate(baseQuery, (query, path) => query.Include(path));
      }

      return baseQuery;
    }
  }
}
