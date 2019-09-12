using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FamiliesApp.Domain.Infrastructure.Repositories
{
    /// <summary>
    /// Represents the most generic data storage.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IDataStorage<T> where T : class
    {
        Task<List<T>> FindAllAsync();

        Task<List<T>> FindAllAsync(
          params string[] includeProperties);

        Task<List<T>> FindAsync(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            int skip = 0,
            int take = 0);

        Task<List<T>> FindAsync(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            int skip = 0,
            int take = 0,
            params string[] includeProperties);

        Task<T> FirstOrDefaultAsync(
            Expression<Func<T, bool>> filter = null);

        Task<T> FirstOrDefaultAsync(
            Expression<Func<T, bool>> filter = null,
            params string[] includeProperties);

        Task<int> Count(Expression<Func<T, bool>> filter = null);

        Task InsertAsync(T entity);

        Task InsertRangeAsync(IEnumerable<T> entities);

        Task UpdateAsync(T entity);

        Task UpdateRangeAsync(IEnumerable<T> entities);

        Task DeleteAsync(T entity);

        Task DeleteRangeAsync(IEnumerable<T> entities);


    }
}
