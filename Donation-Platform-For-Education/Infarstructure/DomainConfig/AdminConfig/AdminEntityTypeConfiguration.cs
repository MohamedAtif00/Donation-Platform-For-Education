using Donation_Platform_For_Education.Domain.Entity.AdminDomain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Donation_Platform_For_Education.Infarstructure.DomainConfig.AdminConfig
{
    public class AdminEntityTypeConfiguration : IEntityTypeConfiguration<Admin>
    {
        void IEntityTypeConfiguration<Admin>.Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.Id).HasConversion(x =>x.value,value=>AdminId.Create(value));

            builder.OwnsOne(x => x.contactInfo);
        }
    }
}
