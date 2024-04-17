using Donation_Platform_For_Education.Domain.Entity.RefreshTokenDomain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Donation_Platform_For_Education.Infarstructure.DomainConfig.RefreshTokenConfig
{
    public class RefreshTokenEntityTypeConfiguration : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasConversion(x =>x.value,x =>RefreshTokenId.Create(x));


        }
    }
}
