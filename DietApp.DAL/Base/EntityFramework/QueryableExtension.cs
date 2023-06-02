using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DietApp.DAL.Base.EntityFramework
{
    public static class QueryableExtension
    {
        public static IQueryable<T> MyIncludes<T>(this IQueryable<T> query, params Expression<Func<T, object>>[] includes) where T : class
        {
            if (includes != null)
            {
                query = includes.Aggregate(query, (a, b) => a.Include(b));
            }
            return query;
        }
    }
}
