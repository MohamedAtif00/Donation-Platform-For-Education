using Donation_Platform_For_Education.Domain.Entity.AdminDomain;
using Donation_Platform_For_Education.Infarstructure.DomainConfig.AdminConfig;
using Microsoft.EntityFrameworkCore;

namespace Donation_Platform_For_Education.Infarstructure.Data
{
    public class ApplicationDbContext : DbContext 
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) 
        {
            
        }

        public DbSet<Admin> admins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly( typeof(ApplicationDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
