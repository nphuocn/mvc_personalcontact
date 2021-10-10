using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MVC.NetCore.Factories
{
    public interface IBaseRepository<T>
    {
        /// <summary>Retrieve a single item using it's primary key, exception if not found</summary>
        /// <param name="primaryKey">
        /// The primary key of the record
        /// </param>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        T Find(object primaryKey);

        /// <summary>Retrieve a single item using it's primary key, exception if not found</summary>
        /// <param name="primaryKey">
        /// The primary key of the record
        /// </param>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        Task<T> FindAsync(object primaryKey);

        /// <summary>Returns all the rows for type T</summary>
        /// <returns>List of Entities</returns>
        IEnumerable<T> GetAll();

        /// <summary>Returns all the rows for type T</summary>
        /// <returns>List of Entities</returns>
        Task<IEnumerable<T>> GetAllAsync();

        /// <summary>Does this item exist by it's primary key</summary>
        /// <param name="primaryKey">
        /// The primary key.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool Exists(object primaryKey);

        /// <summary>
        /// Inserts the data into the table.
        /// </summary>
        /// <param name="entity">
        /// The entity to insert.
        /// </param>
        void Insert(T entity);

        /// <summary>Updates this entity in the database using it's primary key</summary>
        /// <param name="entity">The entity to update</param>
        void Update(T entity);

        /// <summary>Deletes this entry fro the database ** WARNING - Most items should be marked inactive and Updated, not deleted</summary>
        /// <param name="entity">
        /// The entity to delete
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        object Delete(T entity);

        /// <summary>
        /// handle the delete an entity that matched
        /// </summary>
        /// <param name="id">The primakey of the entity </param>
        void Delete(object id);

        /// <summary>
        /// Get() to execute Linq query
        /// </summary>
        /// <param name="filter">filter is condition to run Where command of Linq</param>
        /// <returns></returns>
        IQueryable<T> Get(Expression<Func<T, bool>> filter, List<Expression<Func<T, object>>> includeexpresstion, Func<IQueryable<T>, IOrderedQueryable<T>> orderby);

        /// <summary>
        /// Query() to create QueryRepository helper class
        /// </summary>
        /// <returns></returns>
        IQueryRepository<T> Query();
    }
}
