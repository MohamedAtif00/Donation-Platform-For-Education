using Donation_Platform_For_Education.Domain.Abstarction;
using Donation_Platform_For_Education.Domain.Entity.UserDomain;
using Donation_Platform_For_Education.Domain.Repository.AdminRepo;
using Donation_Platform_For_Education.Domain.Repository.DonorRepo;
using Donation_Platform_For_Education.Domain.Repository.ItemRepo;
using Donation_Platform_For_Education.Domain.Repository.ItemTypeRepo;
using Donation_Platform_For_Education.Infarstructure.Data;
using Donation_Platform_For_Education.Infarstructure.DomainConfig;
using Donation_Platform_For_Education.Infarstructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using System.Text;

namespace Donation_Platform_For_Education.Infarstructure
{
    public static class DependancyInjection
    {

        public static IServiceCollection AddInfrastructure(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("default")));

            services.AddIdentity<User,IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();


            // Configure JWT authentication
            var jwtSettings = configuration.GetSection("JwtSettings");
            var key = Encoding.ASCII.GetBytes(jwtSettings["Secret"]);
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings["Issuer"],
                    ValidAudience = jwtSettings["Audience"],
                    IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(key)
                };
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAdminRepository, AdminRepository>();
            services.AddScoped<IDonorRepository, DonorRepository>();
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IItemTypeRepository, ItemTypeRepository>();

            return services;
        }
    }
}
