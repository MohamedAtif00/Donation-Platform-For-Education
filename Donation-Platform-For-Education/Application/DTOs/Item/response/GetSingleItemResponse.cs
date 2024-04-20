namespace Donation_Platform_For_Education.Application.DTOs.Item.response
{
    public record GetSingleItemResponse(Guid itemId,Guid itemTypeId,Guid donorId,string name,DateTime donationHistory,string description,int? quantity, byte[]? bytes, byte[] image);
   
    
}
