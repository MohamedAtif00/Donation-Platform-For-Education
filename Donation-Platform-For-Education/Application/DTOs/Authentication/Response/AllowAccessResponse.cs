namespace Donation_Platform_For_Education.Application.DTOs.Authentication.Response
{
    public record AllowAccessResponse(string userId, string username, string role, string emai, string token);
    
    
}
