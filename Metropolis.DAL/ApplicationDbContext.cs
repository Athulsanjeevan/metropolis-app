using Metropolis.DAL.Entities;
using Metropolis.DAL.EntityConfiguration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Metropolis.DAL
{
    /// <summary>
    /// This class is used to get access to your tables and views.
    /// </summary> 
    public class ApplicationDbContext :DbContext
    {
        /// <summary>
        /// The ApplicationDbContext public constructor configured with base options.
        /// </summary>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        /// <summary>
        /// Gets or Sets the Activities.
        /// </summary>
        /// <value>
        /// The Activities.
        /// </value>
        public DbSet<Activity> Activities { get; set; }

        /// <summary>
        /// Gets or Sets the Contacts.
        /// </summary>
        /// <value>
        /// The Contacts.
        /// </value>
        public DbSet<Contact> Contacts { get; set; }

        /// <summary>
        /// Here the tables are applied with the constraints which are defined in the classes in EntityConfiguration folder.
        /// </summary>
        public DbSet<Admin> Admins { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ActivityEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ContactEntityConfiguration());
            modelBuilder.ApplyConfiguration(new AdminEntityConfiguration());
        }

       
    }
}
