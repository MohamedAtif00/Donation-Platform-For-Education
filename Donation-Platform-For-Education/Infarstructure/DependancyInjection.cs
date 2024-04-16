﻿using Donation_Platform_For_Education.Domain.Abstarction;
using Donation_Platform_For_Education.Domain.Repository.AdminRepo;
using Donation_Platform_For_Education.Domain.Repository.DonorRepo;
using Donation_Platform_For_Education.Domain.Repository.ItemRepo;
using Donation_Platform_For_Education.Domain.Repository.ItemTypeRepo;
using Donation_Platform_For_Education.Infarstructure.Data;
using Donation_Platform_For_Education.Infarstructure.DomainConfig;
using Donation_Platform_For_Education.Infarstructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace Donation_Platform_For_Education.Infarstructure
{
    public static class DependancyInjection
    {

        public static IServiceCollection AddInfrastructure(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("default")));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAdminRepository, AdminRepository>();
            services.AddScoped<IDonorRepository, DonorRepository>();
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IItemTypeRepository, ItemTypeRepository>();

            return services;
        }
    }
}
