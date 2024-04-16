using Donation_Platform_For_Education.Domain.Entity.DonorDomain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Donation_Platform_For_Education.Infarstructure.DomainConfig.DonorConfig
{
    public class DonorEntityTypeConfiguration : IEntityTypeConfiguration<Donor>
    {
        public void Configure(EntityTypeBuilder<Donor> builder)
        {
            builder.HasKey(x =>x.Id);

            builder.Property(x => x.Id).HasConversion(x =>x.value,x =>DonorId.Create(x));

            builder.HasMany(x =>x.donationHistories).WithOne(x =>x.donor);


        }


    }
}
