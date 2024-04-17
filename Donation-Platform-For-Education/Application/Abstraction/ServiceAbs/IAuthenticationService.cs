using Ardalis.Result;
using Donation_Platform_For_Education.Application.DTOs.JwtSetting;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Donation_Platform_For_Education.Application.Abstraction.ServiceAbs
{
    public interface IAuthenticationService
    {
        Task<Result<string>> CheckUsername(string username);
        Task<Result> ConfirmEmail(string userId, string code);
        Task<string> GenerateAccessToken(ClaimsIdentity claimsIdentity);
        Task<ClaimsIdentity> GenerateClaimsIdentity(IdentityUser<Guid> user, string role);
        Task<string> GenerateRefreshToken(IdentityUser<Guid> newUser);
        Task<Result<JwtTokenDto>> Login(string username, string password,string role);
        Task<Result<JwtTokenDto>> Register(string Username, string Email, string Password, string Role);
    }
}