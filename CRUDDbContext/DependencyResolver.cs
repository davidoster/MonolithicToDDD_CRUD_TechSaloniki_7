using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDDbContext
{
    public static class DependencyResolver
    {
        public static IServiceCollection AddDatabaseContext(this IServiceCollection services, IConfiguration configuration)
        {
            // Add a new instance of the MarkingDbContext to the service collection with a database provider
            services.AddDbContext<CrudDbContext>
            (options => options.
                         UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            //services.AddScoped< CrudDbContext>();   <---Uncomment this!!
            return services;

            // SEED DATABASE


            //}
        }
    }
}
