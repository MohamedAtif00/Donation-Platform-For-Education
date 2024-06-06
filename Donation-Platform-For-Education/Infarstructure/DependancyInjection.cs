using Donation_Platform_For_Education.Domain.Abstarction;
using Donation_Platform_For_Education.Domain.Repository.ItemRepo;
using Donation_Platform_For_Education.Domain.Repository.ItemTypeRepo;
using Donation_Platform_For_Education.Infarstructure.Data;
using Donation_Platform_For_Education.Infarstructure.DomainConfig;
using Donation_Platform_For_Education.Infarstructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Donation_Platform_For_Education.Domain.Repository.RefreshTokenRepo;
using Donation_Platform_For_Education.Application.DTOs.JwtSetting;
using Microsoft.IdentityModel.Tokens;
using Donation_Platform_For_Education.Domain.Repository.RequestRepo;

namespace Donation_Platform_For_Education.Infarstructure
{
    public static class DependancyInjection
    {

        public static IServiceCollection AddInfrastructure(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("default")));


            services.AddDefaultIdentity<IdentityUser<Guid>>(options =>
            {
                // Configure password requirements
                options.Password.RequiredLength = 8; // Minimum password length
                options.Password.RequireDigit = false; // Requires at least one digit
                options.Password.RequireLowercase = false; // Requires at least one lowercase letter
                options.Password.RequireUppercase = false; // Requires at least one uppercase letter
                options.Password.RequireNonAlphanumeric = false; // Requires at least one non-alphanumeric character

            }).AddRoles<IdentityRole<Guid>>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();


            var jwtSettings = configuration.GetSection("JwtSettings");

            var setting = services.Configure<JwtSettings>(jwtSettings);

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.SaveToken = true;
                x.ClaimsIssuer = jwtSettings["Issuer"];
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ClockSkew = TimeSpan.Zero,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["SigningKey"])),
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings["Issuer"],
                    ValidAudience = jwtSettings["Audiance"]

                };
                x.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                            context.Response.Headers.Add("IS_TOKEN_EXPIRED", "Y");
                        return Task.CompletedTask;

                    }
                };

            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IItemTypeRepository, ItemTypeRepository>();
            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
            services.AddScoped<IRequestRepository,RequestRepository>();

            return services;
        }
    }
}
