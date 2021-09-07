using System;
using System.Linq;
using System.Linq.Expressions;

namespace Common.Utility.Contracts
{
    public interface IExpressionFilter
    {
        Expression<Func<T, bool>> GetExpression<T>(string FilterExpression, out bool isValid);
        IQueryable<T> OrderByDynamic<T>(IQueryable<T> query, string sortColumn, out bool isValid, bool sortOrderAsc = true);
    }
}
