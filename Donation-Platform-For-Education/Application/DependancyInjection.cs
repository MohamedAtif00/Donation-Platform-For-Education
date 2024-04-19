using Donation_Platform_For_Education.Application.Abstraction.ServiceAbs;
using Donation_Platform_For_Education.Application.Service;

namespace Donation_Platform_For_Education.Application
{
    public static class DependancyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<IDonorService, DonorService>();
            services.AddScoped<IItemService, ItemService>();
            services.AddScoped<IItemTypeService, ItemTypeService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IRequestService, RequestService>();

            return services;
        }
    }
}
