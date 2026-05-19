using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanySystem.DAL
{
    public static class DALServicesExtension
    {
        public static void AddDALServicesExtension(this IServiceCollection services,IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<AppDbContext>(options =>
             options.UseSqlServer(connectionString));
             services.AddScoped<IUnitOfWork, UnitOfWork>();
             services.AddScoped<ICategoryRepository, CategoryRepository>();
             services.AddScoped<IProductRepository, ProductRepository>();

        }
    }
}
