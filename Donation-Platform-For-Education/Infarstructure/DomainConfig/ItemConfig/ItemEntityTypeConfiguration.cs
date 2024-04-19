using Donation_Platform_For_Education.Domain.Entity.DonorDomain;
using Donation_Platform_For_Education.Domain.Entity.ItemDomain;
using Donation_Platform_For_Education.Domain.Entity.ItemTypeDomain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Donation_Platform_For_Education.Infarstructure.DomainConfig.ItemConfig
{
    public class ItemEntityTypeConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x =>x.Id).HasConversion(x=>x.value,x =>ItemId.Create(x));

            builder.Property(x =>x.itemTypeId).HasConversion(x =>x.value,x =>ItemTypeId.Create(x));

            

        }
    }
}
