using MVC.NetCore.Commons;
using MVC.NetCore.IDataServices;
using MVC.NetCore.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MVC.NetCore.Business
{
    public class PersonalContactBusiness : IDisposable
    {
        #region Fields

        private readonly IPersonalContactDataService _personalContactDataService;

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonalContactBusiness"/> class.
        /// </summary>
        /// <param name="personalContactDataService">
        /// The personal contact data service which process the data access for personal contact.
        /// </param>
        public PersonalContactBusiness(IPersonalContactDataService personalContactDataService)
        {
            _personalContactDataService = personalContactDataService;
        }

        public async Task<List<PersonalContactModel>> GetAllAsync()
        {
            List<PersonalContactModel> personalContacts = null;
            try
            {
                // Get current personal contact by Id
                personalContacts = await _personalContactDataService.GetAllAsync() as List<PersonalContactModel>;
            }
            catch (InvalidOperationException)
            {
                // Write traking log here.
            }

            return personalContacts;
        }

        public async Task<PersonalContactModel> FindAsync(int? id)
        {
            PersonalContactModel personalContact= null;
            try
            {
                // Get current personal contact by Id
                personalContact = await _personalContactDataService.GetByIdAsync(id);
            }
            catch (InvalidOperationException)
            {
                // Write traking log here.
            }

            return personalContact;
        }

        public async Task<ModelResult> CreatePersonalContactAsync(PersonalContactModel model)
        {
            // Declare a ModelResult to return the result of create personal contact & message code to view.
            ModelResult result = new ModelResult(false, "InternalServerError");

            PersonalContactModel personalContact = model;
            try
            {
                // If personal contact is not exist in database, create new personal contact.
                if (personalContact.Id == 0)
                {
                    // Call the method to insert new personal contact.
                    bool isSucceeded = await _personalContactDataService.InsertAsync(model);
                    result.Status = isSucceeded;
                    if (isSucceeded)
                    {
                        result.MessageCode = "Success";
                    }
                    else
                    {
                        result.MessageCode = "Fail";
                    }
                }
                else
                {
                    // Call the method to insert new personal contact.
                    bool isSucceeded = await _personalContactDataService.UpdateAsync(model);
                    result.Status = isSucceeded;
                    if (isSucceeded)
                    {
                        result.MessageCode = "Success";
                    }
                    else
                    {
                        result.MessageCode = "Fail";
                    }
                }
            }
            catch (InvalidOperationException)
            {
                result.Status = false;
                result.MessageCode = "InvalidOperationException";
                // Write traking log here.
            }

            return result;
        }

        public async Task<bool> DeletePersonalContactAsync(int id)
        {
            bool isSucceeded = false;
            PersonalContactModel personalContact = _personalContactDataService.GetById(id);
            try
            {
                if (personalContact != null)
                {
                    // Call the method to insert new personal contact.
                    isSucceeded = await _personalContactDataService.DeleteAsync(personalContact);
                }
            }
            catch (InvalidOperationException)
            {
                // Write traking log here.
            }

            return isSucceeded;
        }

        #region Dispose

        /// <summary>
        /// Dispose all using service.
        /// </summary>
        public void Dispose()
        {
            _personalContactDataService.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
