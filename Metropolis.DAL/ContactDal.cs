using Metropolis.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Metropolis.DAL
{
    /// <summary>
    /// This class describes the method to retrieve the contact details of Metropolis City Corporation .
    /// </summary> 
    public class ContactDal : IContactDal
    {
        private readonly ApplicationDbContext _dbContext;

        public ContactDal(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary> 
        /// Defines a method to return contact information.
        /// </summary>
        /// <return>
        /// Contact information of Metropolis City Corporation.
        /// </return>
        public List<Contact> AllContact()
        {
            return _dbContext.Contacts.ToList();

        }
    }
}
