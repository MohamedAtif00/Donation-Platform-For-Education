namespace Donation_Platform_For_Education.Application.DTOs.Item.response
{
    public record FileDownloadResponse(byte[] bytes,string fileName,string contentType);
    
    
}
