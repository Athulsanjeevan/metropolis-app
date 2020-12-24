 using System;
using System.Collections.Generic;
using System.Text;

namespace Metropolis.DAL.Entities
{
    /// <summary>
    /// This class contains the schema of the Contact entity.
    /// </summary> 
    public class Contact
    {
            public int ContactId {get;set;}
            public string ContactName { get; set; }

            public string ContactEmailId { get; set; }

            public int ContactPhoneNumber { get; set; }


    }
}

