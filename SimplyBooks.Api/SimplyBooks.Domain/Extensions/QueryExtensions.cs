using SimplyBooks.Domain.QueryModels;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace SimplyBooks.Domain.Extensions
{
    public static class QueryExtensions
    {
        public static IQueryable<TSource> OrderByDynamic<TSource, TKey>(this IQueryable<TSource> query,
            Expression<Func<TSource, TKey>> keySelector, OrderDirection sortDirection)
        {
            var orderedQuery = sortDirection == OrderDirection.ASC
                ? query.OrderBy(keySelector)
                : query.OrderByDescending(keySelector);

            return orderedQuery;
        }
    }
}
