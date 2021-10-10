using System;
using System.Linq;
using System.Linq.Expressions;

namespace MVC.NetCore.Factories
{
    public interface IQueryRepository<T>
    {
        /// <summary>
        ///  This function save the condition to run "Where" expression of Linq later
        /// </summary>
        /// <param name="filter">filter is "Where" expression of Linq to run later </param>
        /// <returns></returns>
        IQueryRepository<T> Filter(Expression<Func<T, bool>> filter);

        /// <summary>
        /// Get() to pass the filter back to Get() of parent class to execute Linq
        /// </summary>
        /// <returns></returns>
        IQueryable<T> Get();

        /// <summary>
        /// Encapsulates a Include method that has one parameter and returns a value of the type specified
        /// </summary>
        /// <param name="expression">  The expression. </param>
        /// <returns></returns>
        IQueryRepository<T> Include(Expression<Func<T, object>> include);

        /// <summary>
        ///  Encapsulates a Order method that has one parameter and returns a value of the type specified by the <see cref="T"/> parameter.
        /// </summary>
        /// <param name="orderBy">The order by </param>
        /// <returns></returns>
        IQueryRepository<T> OrderBy(Func<IQueryable<T>, IOrderedQueryable<T>> orderBy);
    }
}
