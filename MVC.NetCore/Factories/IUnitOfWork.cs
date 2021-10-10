using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace MVC.NetCore.Factories
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Call this to commit unit of work
        /// </summary>
        void Commit();

        /// <summary>
        /// Call this to commit unit of work
        /// </summary>
        Task CommitAsync();

        /// <summary>
        /// Return the database reference for this uow
        /// </summary>
        DbContext Db { get; }

        /// <summary>
        /// Declare repository 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IBaseRepository<T> Repository<T>() where T : class;
    }
}
