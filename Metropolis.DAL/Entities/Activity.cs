using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Metropolis.DAL.Entities
{
    /// <summary>
    /// This class contains the schema of the Activity Entity.
    /// </summary> 
    public class Activity
    {
        public int ActivityId { get; set; }

        public string ActivityName { get; set; }

        public string ActivityType { get; set; }

        public DateTime ScheduledDate { get; set; }

        public string StreetName { get; set; }

        public string AlternativeStreet { get; set; }

        public bool IsClosed { get; set; }


    }
}
