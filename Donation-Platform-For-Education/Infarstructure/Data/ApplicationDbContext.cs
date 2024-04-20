using Donation_Platform_For_Education.Domain.Entity.ItemDomain;
using Donation_Platform_For_Education.Domain.Entity.ItemTypeDomain;
using Donation_Platform_For_Education.Domain.Entity.RefreshTokenDomain;
using Donation_Platform_For_Education.Domain.Entity.RequestDomain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Donation_Platform_For_Education.Infarstructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser<Guid>,IdentityRole<Guid>,Guid>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }


        public DbSet<Item> items { get; set; }
        public DbSet<ItemType> itemTypes { get; set; }
        public DbSet<RefreshToken> refreshTokens { get; set; }
        public DbSet<Request> Requests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly( typeof(ApplicationDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
