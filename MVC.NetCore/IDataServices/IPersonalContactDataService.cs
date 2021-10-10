using MVC.NetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.NetCore.IDataServices
{
    /// <summary>
    /// The IPersonalContactDataService interface.
    /// </summary>
    public interface IPersonalContactDataService
    {
        /// <summary>
        /// Get information of all personal contacts
        /// </summary>
        /// <returns></returns>
        IList<PersonalContactModel> GetAll();

        /// <summary>
        /// Get information of all personal contacts
        /// </summary>
        /// <returns></returns>
        Task<IList<PersonalContactModel>> GetAllAsync();

        /// <summary>
        /// Get information of personal contact by Id
        /// </summary>
        /// <param name="Id">The current personal contact id</param>
        /// <returns>
        /// The PersonalContact entity <see cref="PersonalContact"/>.
        /// </returns>
        PersonalContactModel GetById(int Id);

        /// <summary>
        /// Get information of personal contact by Id
        /// </summary>
        /// <param name="Id">The current personal contact id</param>
        /// <returns>
        /// The PersonalContact entity <see cref="PersonalContact"/>.
        /// </returns>
        Task<PersonalContactModel> GetByIdAsync(int? Id);

        /// <summary>
        /// Create new personal contact
        /// </summary>
        /// <param name="personalContact">
        /// The new personal contact
        /// </param>
        /// <returns>The result of new personal contact</returns>
        bool Insert(PersonalContactModel personalContact);

        /// <summary>
        /// Create new personal contact
        /// </summary>
        /// <param name="personalContact">
        /// The new personal contact
        /// </param>
        /// <returns>The result of new personal contact</returns>
        Task<bool> InsertAsync(PersonalContactModel personalContact);

        /// <summary>
        /// Update personal contact
        /// </summary>
        /// <param name="personalContact">
        /// The current personal contact to update
        /// </param>
        /// <returns>The result of update personal contact</returns>
        bool Update(PersonalContactModel personalContact);

        /// <summary>
        /// Update personal contact
        /// </summary>
        /// <param name="personalContact">
        /// The current personal contact
        /// </param>
        /// <returns>The result of new personal contact</returns>
        Task<bool> UpdateAsync(PersonalContactModel personalContact);

        /// <summary>
        /// Delete personal contact
        /// </summary>
        /// <param name="personalContact">
        /// The current personal contact to delete.
        /// </param>
        /// <returns>The result of detete personal contact.</returns>
        bool Delete(PersonalContactModel personalContact);

        /// <summary>
        /// Delete personal contact
        /// </summary>
        /// <param name="personalContact">
        /// The current personal contact to delete.
        /// </param>
        /// <returns>The result of detete personal contact.</returns>
        Task<bool> DeleteAsync(PersonalContactModel personalContact);

        /// <summary>
        /// Dispose to free resources
        /// </summary>
        void Dispose();
    }
}
