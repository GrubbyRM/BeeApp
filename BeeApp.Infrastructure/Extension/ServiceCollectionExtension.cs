using BeeApp.Domain.Interfaces;
using BeeApp.Infrastructure.Persistence;
using BeeApp.Infrastructure.Seeders;
using BeeApp.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeApp.Infrastructure.Extension
{
    public static class ServiceCollectionExtension
    {
        // BJ: Login into db by Dependency Injection
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BeeAppDbContext>(options => options.UseSqlServer(
                configuration.GetConnectionString("BeeApp")));

            services.AddScoped<BeeAppSeeder>();

            //BJ: register addInspectionRepository
            services.AddScoped<IInspectionRepository, InspectionRepository>();
        }
    }
}
