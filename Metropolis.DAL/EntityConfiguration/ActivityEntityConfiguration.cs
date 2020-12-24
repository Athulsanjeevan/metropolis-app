using Metropolis.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Metropolis.DAL.EntityConfiguration
{
    /// <summary>
    /// This class contains a Configure method to apply contraints to the fields of Activity entitity.
    /// </summary> 
    public class ActivityEntityConfiguration : IEntityTypeConfiguration<Activity>
    {
        public void Configure(EntityTypeBuilder<Activity> builder)
        {
            builder.HasKey(i => i.ActivityId);

            builder.Property(t => t.ActivityName)
                   .IsRequired();

            builder.Property(p => p.ActivityType)
                   .IsRequired();

            builder.Property(x => x.ScheduledDate)
                   .IsRequired();
            
            builder.Property(o => o.StreetName)
                   .IsRequired();
            
            builder.Property(y => y.IsClosed)
                   .IsRequired();
        }     

    }
}
