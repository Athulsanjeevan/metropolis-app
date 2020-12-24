using Metropolis.DAL.Entities;
using System.Collections.Generic;

namespace Metropolis.DAL
{
    /// <summary>
    /// Defines the interface for ContactDal.
    /// </summary>
    public interface IContactDal
    {
        /// <summary> 
        /// Declares a method to return contact information.
        /// </summary>
        /// <return>
        /// Contact information of Metropolis City Corporation.
        /// </return>
        List<Contact> AllContact();
    }
}
