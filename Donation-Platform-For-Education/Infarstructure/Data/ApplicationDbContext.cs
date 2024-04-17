using Donation_Platform_For_Education.Domain.Entity.AdminDomain;
using Donation_Platform_For_Education.Domain.Entity.DonorDomain;
using Donation_Platform_For_Education.Domain.Entity.ItemDomain;
using Donation_Platform_For_Education.Domain.Entity.ItemTypeDomain;
using Donation_Platform_For_Education.Infarstructure.DomainConfig.AdminConfig;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Donation_Platform_For_Education.Infarstructure.Data
{
    public class ApplicationDbContext : IdentityDbContext 
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) 
        {
            
        }

        public DbSet<Admin> admins { get; set; }
        public DbSet<Donor> donors { get; set; }
        public DbSet<Item> items { get; set; }
        public DbSet<ItemType> itemTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly( typeof(ApplicationDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
