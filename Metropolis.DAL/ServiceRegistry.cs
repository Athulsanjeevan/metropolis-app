using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Metropolis.DAL
{
    /// <summary>
    /// This class contains the method to register data services .
    /// </summary> 
    public static class ServiceRegistry
    {
        /// <summary>
        /// Defines a method to register data services.
        /// </summary>
        /// <param name="services">The service collection for ApplicationDbContext .
        /// </param>
        /// <param name="configuration">The configuration for ApplicationDbContext.
        /// </param>
        public static void RegisterDataServices(this IServiceCollection services, IConfiguration configuration)
        {
            var ConnectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(ConnectionString));

        }
    }
}
