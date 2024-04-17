namespace Donation_Platform_For_Education.Application.DTOs.Item.Request
{
    public record CreateItemRequest(Guid itemTypeId,Guid userId,string description,string name,int? quantity, IFormFile? file,IFormFile? image);
    
    
}
