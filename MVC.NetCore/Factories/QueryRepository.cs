using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MVC.NetCore.Factories
{
    public class QueryRepository<T> : IQueryRepository<T> where T : class
    {
        /// <summary>
        /// filter variable to keep filter condition to use later when running Linq in Get() function
        /// </summary>
        private Expression<Func<T, bool>> _filter;

        /// <summary>
        /// The properties that should be pass into the query statementW
        /// </summary>
        private readonly List<Expression<Func<T, object>>> _includeexpression;

        /// <summary>
        /// To keep the parent class BaseRepository to run Get() function of parent class
        /// </summary>
        private readonly BaseRepository<T> _baseRepository;

        /// <summary>
        /// Encapsulates a OrderBy method that has one parameter and returns a value of the type specified by the <see cref="TEntity"/> parameter.
        /// </summary>
        private Func<IQueryable<T>, IOrderedQueryable<T>> _orderByQuerable;

        /// <summary>
        /// QueryRepository() is a constructor to take in the parent class
        /// </summary>
        /// <param name="baseRepository"></param>
        public QueryRepository(BaseRepository<T> baseRepository)
        {
            _baseRepository = baseRepository;
            _includeexpression = new List<Expression<Func<T, object>>>();
        }

        /// <summary>
        /// implement Filter() function of IQueryRepository
        /// </summary>
        /// <param name="filter">filter is "Where" expression of Linq to run later </param>
        /// <returns></returns>
        public IQueryRepository<T> Filter(Expression<Func<T, bool>> filter)
        {
            _filter = filter;
            return this;
        }

        /// <summary>
        /// Get() to implement Get() interface of IQueryRepository to pass filter condtion to
        /// Get() function of BaseRepository
        /// </summary>
        /// <returns></returns>
        public IQueryable<T> Get()
        {
            return _baseRepository.Get(_filter, _includeexpression, _orderByQuerable);
        }

        /// <summary>
        /// Include() to implement Include() interface of IQueryRepository  to pass expresstion condtion to
        /// </summary>
        /// <param name="include"></param>
        /// <returns></returns>
        public IQueryRepository<T> Include(Expression<Func<T, object>> expresstion)
        {
            _includeexpression.Add(expresstion);
            return this;
        }

        /// <summary>
        ///  OrderBy() to implement OrderBy() interface of IQueryRepository  to pass orderBy condtion to
        /// </summary>
        /// <param name="orderBy"></param>
        /// <returns></returns>
        public IQueryRepository<T> OrderBy(Func<IQueryable<T>, IOrderedQueryable<T>> orderBy)
        {
            _orderByQuerable = orderBy;
            return this;
        }
    }
}
