using MVC.NetCore.Factories;
using System;

namespace MVC.NetCore.DataServices
{
    public abstract class BaseServices : IDisposable
    {
        /// <summary>
        ///  Unit of Work for each inheritted class 
        /// </summary>
        protected IUnitOfWork _unitOfWork;

        /// <summary>
        /// Call the protected dispose method
        /// </summary>
        public abstract void Dispose();
    }
}
