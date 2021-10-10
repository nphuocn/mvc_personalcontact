using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MVC.NetCore.Factories
{
    /// <summary>
    /// Base class for all SQL based service classes
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly DbContext _dbContext;

        /// <summary>
        /// The db set.
        /// </summary>
        private readonly DbSet<T> _dbSet;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRepository{T}"/> class.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        public BaseRepository(DbContext context)
        {
            if (null == context)
            {
                throw new ArgumentNullException("context");
            }
            _dbContext = context;
            this._dbSet = context.Set<T>();
        }

        /// <summary>
        /// Returns the object with the primary key specifies or throws
        /// </summary>
        /// <param name="primaryKey">
        /// The primary key
        /// </param>
        /// <returns>
        /// The result mapped to the specified type
        /// </returns>
        public T Find(object primaryKey)
        {
            var dbResult = this._dbSet.Find(primaryKey);
            return dbResult;
        }

        /// <summary>
        /// Returns the object with the primary key specifies or throws
        /// </summary>
        /// <param name="primaryKey">
        /// The primary key
        /// </param>
        /// <returns>
        /// The result mapped to the specified type
        /// </returns>
        public async Task<T> FindAsync(object primaryKey)
        {
            var dbResult = await this._dbSet.FindAsync(primaryKey);
            return dbResult;
        }

        /// <summary>
        /// The exists.
        /// </summary>
        /// <param name="primaryKey">
        /// The primary key.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Exists(object primaryKey)
        {
            return this._dbSet.Find(primaryKey) != null;
        }

        /// <summary>
        /// The insert.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public void Insert(T entity)
        {
            dynamic obj = this._dbSet.Add(entity);
            _dbContext.Entry(entity).State = EntityState.Added;
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        public virtual void Update(T entity)
        {
            this._dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public object Delete(T entity)
        {
            if (_dbContext.Entry(entity).State == EntityState.Detached)
            {
                this._dbSet.Attach(entity);
            }

            dynamic obj = this._dbSet.Remove(entity);
            return obj;
        }

        /// <summary>
        /// The get all.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public IEnumerable<T> GetAll()
        {
            return this._dbSet.AsEnumerable().ToList();
        }
        /// <summary>
        /// The get all.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await this._dbSet.ToListAsync();
        }

        /// <summary>
        /// handle the delete an entity the given up 
        /// </summary>
        /// <param name="id">A new instance of the <see cref="TEntity"/> class</param>
        public virtual void Delete(object id)
        {
            var entity = this._dbSet.Find(id);
            Delete(entity);
        }

        /// <summary>
        /// To implement Query() interface of BaseRepository
        /// </summary>
        /// <returns></returns>
        public IQueryRepository<T> Query()
        {
            var queryRepository = new QueryRepository<T>(this);
            return queryRepository;
        }

        /// <summary>
        /// Get() to implement Get() interface of IBaseRepository
        /// to execuate Linq query
        /// </summary>
        /// <param name="filter">filter is condition to run Where command of Linq</param>
        /// <returns></returns>
        public IQueryable<T> Get(Expression<Func<T, bool>> filter, List<Expression<Func<T, object>>> includeexpresstion, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
        {
            IQueryable<T> query = _dbSet;

            if (includeexpresstion != null)
            {
                includeexpresstion.ForEach(i => query = query.Include(i));
            }

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            return query;
        }
    }
}
