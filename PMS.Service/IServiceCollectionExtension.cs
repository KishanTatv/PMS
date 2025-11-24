using Microsoft.Extensions.DependencyInjection;
using PMS.Service.Implements;
using PMS.Service.Interface;

namespace PMS.Service
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            //services.AddKeyedScoped<IAuthService, AuthService>("Admin");
            services.AddScoped<IAdminService, AdminService>();

            services.AddScoped<IApplicationUserService, ApplicationUserService>();
            services.AddScoped<IShoppingCartService, ShoppingCartService>();
            services.AddScoped<IOrderDetailService, OrderDetailService>();

            return services;
        }
    }
}
