using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FamiliesApp.Domain.Infrastructure.Repositories
{
    public static class DataStorageExtended
    {
        public static IQueryable<TEntity> AddIncludes<TEntity>(
            this IQueryable<TEntity> query,
            params string[] includeProperties)
                where TEntity : class
        {
            if (includeProperties != null)
            {
                foreach (var property in includeProperties)
                {
                    query = query.Include(property);
                }
            }

            return query;
        }
    }
}