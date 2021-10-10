using Microsoft.EntityFrameworkCore;
using MVC.NetCore.Context;
using System.Threading.Tasks;

namespace MVC.NetCore.Factories
{
    public class UnitOfWork : IUnitOfWork
    {

        /// <summary>
        /// The _db.
        /// </summary>
        private readonly MVCDbContext _db;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
        /// </summary>
        public UnitOfWork(MVCDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// The commit.
        /// </summary>
        public void Commit()
        {
            _db.SaveChanges();

        }

        /// <summary>
        /// The commit.
        /// </summary>
        public async Task CommitAsync()
        {
            await _db.SaveChangesAsync();

        }

        /// <summary>
        /// Gets the db.
        /// </summary>
        public DbContext Db
        {
            get { return _db; }
        }

        /// <summary>
        /// The dispose.
        /// </summary>
        public void Dispose()
        {
            _db.Dispose();
        }

        /// <summary>
        /// The repository.
        /// </summary>
        /// <typeparam name="T">
        /// </typeparam>
        /// <returns>
        /// The <see cref="IBaseRepository{T}"/>.
        /// </returns>
        public IBaseRepository<T> Repository<T>() where T : class
        {
            var repository = new BaseRepository<T>(_db);
            return repository;
        }
    }
}
