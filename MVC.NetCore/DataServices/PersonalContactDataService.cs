using MVC.NetCore.Factories;
using MVC.NetCore.IDataServices;
using MVC.NetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.NetCore.DataServices
{
    public class PersonalContactDataService : BaseServices, IPersonalContactDataService
    {
        #region Contructor

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonalContactDataService"/> class.
        /// </summary>
        /// <param name="unitOfWork">
        /// The unit of work which process data access.
        /// </param>
        public PersonalContactDataService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #endregion

        public bool Insert(PersonalContactModel personalContact)
        {
            try
            {
                // Call the method insert new personal contact.
                _unitOfWork.Repository<PersonalContactModel>().Insert(personalContact);

                // Process insert to database.
                _unitOfWork.Commit();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> InsertAsync(PersonalContactModel personalContact)
        {
            try
            {
                // Call the method insert new personal contact.
                _unitOfWork.Repository<PersonalContactModel>().Insert(personalContact);

                // Process insert to database.
                await _unitOfWork.CommitAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(PersonalContactModel personalContact)
        {
            try
            {
                // Call the method update existed personal contact.
                _unitOfWork.Repository<PersonalContactModel>().Update(personalContact);

                // Process insert to database.
                _unitOfWork.Commit();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> UpdateAsync(PersonalContactModel personalContact)
        {
            try
            {
                // Call the method update existed personal contact.
                _unitOfWork.Repository<PersonalContactModel>().Update(personalContact);

                // Process insert to database.
                await _unitOfWork.CommitAsync();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Delete(PersonalContactModel personalContact)
        {
            try
            {
                // Call the method delete existed personal contact.
                _unitOfWork.Repository<PersonalContactModel>().Delete(personalContact);

                // Process insert to database.
                _unitOfWork.Commit();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteAsync(PersonalContactModel personalContact)
        {
            try
            {
                // Call the method delete existed personal contact.
                _unitOfWork.Repository<PersonalContactModel>().Delete(personalContact);

                // Process insert to database.
                await _unitOfWork.CommitAsync();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IList<PersonalContactModel> GetAll()
        {
            try
            {
                List< PersonalContactModel > personalContacts = _unitOfWork.Repository<PersonalContactModel>().GetAll().ToList();
                return personalContacts;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IList<PersonalContactModel>> GetAllAsync()
        {
            try
            {
                List<PersonalContactModel> personalContacts = await _unitOfWork.Repository<PersonalContactModel>().GetAllAsync() as List<PersonalContactModel>;
                return personalContacts;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public PersonalContactModel GetById(int Id)
        {
            try
            {
                // Get the current personal contact by Id.
                PersonalContactModel personalContact = _unitOfWork.Repository<PersonalContactModel>().Find(Id);
                return personalContact;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<PersonalContactModel> GetByIdAsync(int? Id)
        {
            try
            {
                // Get the current personal contact by Id.
                PersonalContactModel personalContact = await _unitOfWork.Repository<PersonalContactModel>().FindAsync(Id);
                return personalContact;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Dispose to free resources
        /// </summary>
        public override void Dispose()
        {
            _unitOfWork.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
