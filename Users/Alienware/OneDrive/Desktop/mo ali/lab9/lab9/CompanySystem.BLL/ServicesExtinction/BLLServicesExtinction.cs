using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CompanySystem.BLL.Mangers.AuthManager;

namespace CompanySystem.BLL
{
    public static class BLLServicesExtinction
    {
        public static void AddBLLServicesExtinction(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICategoryManger, CategoryManger>();
            services.AddScoped<IProductManger, ProductManger>();
            services.AddScoped<IAuthManager, AuthManager>();
        }
    }
}
