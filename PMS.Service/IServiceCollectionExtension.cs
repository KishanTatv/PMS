using Microsoft.Extensions.DependencyInjection;
using PMS.Service.Implements;
using PMS.Service.Interface;

namespace PMS.Service
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAdminService, AdminService>();

            return services;
        }
    }
}
