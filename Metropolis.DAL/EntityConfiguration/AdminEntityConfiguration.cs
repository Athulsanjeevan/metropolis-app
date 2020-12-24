using Metropolis.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metropolis.DAL.EntityConfiguration
{
    public class AdminEntityConfiguration : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(u => u.Email)
                   .IsRequired();

            builder.Property(t => t.Password)
                   .IsRequired();
        }
    }
}
