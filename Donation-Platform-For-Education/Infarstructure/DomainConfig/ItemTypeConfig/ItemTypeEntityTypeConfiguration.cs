using Donation_Platform_For_Education.Domain.Entity.ItemTypeDomain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Donation_Platform_For_Education.Infarstructure.DomainConfig.ItemTypeConfig
{
    public class ItemTypeEntityTypeConfiguration : IEntityTypeConfiguration<ItemType>
    {
        
        public void Configure(EntityTypeBuilder<ItemType> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x =>x.Id).HasConversion(x =>x.value ,x=>ItemTypeId.Create(x));

        }
    }
}
