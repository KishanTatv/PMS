using Microsoft.Extensions.DependencyInjection;
using PMS.Repository.Implements;
using PMS.Repository.Interface;

namespace PMS.Repository
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAdminRepository, AdminRepository>();
            return services;
        }
    }
}
