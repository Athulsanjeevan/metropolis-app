using Metropolis.DAL.Entities;
using System.Collections.Generic;

namespace Metropolis.BLL
{
    /// <summary>
    ///  Defines the interface for the ContactBLL.
    /// </summary>
    public interface IContactBll
    {
        /// <summary>
        /// Declares a method to get the contact details.
        /// </summary>
        /// <returns>The contact details</returns>
        List<Contact> GetContact();
    }
}
