using Donation_Platform_For_Education.Domain.Entity.ItemDomain;
using Donation_Platform_For_Education.Domain.Entity.RequestDomain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Donation_Platform_For_Education.Infarstructure.DomainConfig.RequestConfig
{
    public class RequestEntityTypeConfiguration : IEntityTypeConfiguration<Request>
    {
        public void Configure(EntityTypeBuilder<Request> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasConversion(x =>x.value,x =>RequestId.Create(x));

            builder.Property(x => x.itemId).HasConversion(x =>x.value,x =>ItemId.Create(x));

            builder.HasOne(x => x.item).WithMany(x => x.requests).OnDelete(DeleteBehavior.NoAction);
            
        }
    }
}
