using Donation_Platform_For_Education.Domain.Entity.ItemDomain;
using Donation_Platform_For_Education.Domain.Entity.ItemTypeDomain;

namespace Donation_Platform_For_Education.Application.DTOs.Item.response
{
    public record AllItemsResponse(Guid id, Guid itemTypeId,Guid donor, string name, string description, int? quantity, FileResponse? image);
    
    
}
