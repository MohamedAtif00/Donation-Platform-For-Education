using Donation_Platform_For_Education.Domain.Entity.DonorDomain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Donation_Platform_For_Education.Infarstructure.DomainConfig.DonorConfig
{
    public class DonationHistoryEntityTypeConfiguration : IEntityTypeConfiguration<DonationHistory>
    {
        public void Configure(EntityTypeBuilder<DonationHistory> builder)
        {
            builder.HasKey(d => d.Id);

            builder.Property(x => x.Id).HasConversion(x =>x.value,x =>DonationHistoryId.Create(x));

            builder.Property(x => x.donorId).HasConversion(x => x.value, x => DonorId.Create(x));

            builder.HasOne(x => x.donor).WithMany(x => x.donationHistories);
        }
    }
}
