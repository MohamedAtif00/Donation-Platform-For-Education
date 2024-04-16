using Ardalis.Result;
using Donation_Platform_For_Education.Domain.Entity.AdminDomain;

namespace Donation_Platform_For_Education.Application.Abstraction.ServiceAbs
{
    public interface IAdminService
    {
        Task<Result<Admin>> Create(string name, string email, string phoneNumber);
        Task<Result> DeleteAdmine(Guid id);
        Task<Result<List<Admin>>> GetAllAdmins();
        Task<Result<Admin>> GetSingleAdmin(Guid id);
        Task<Result<Admin>> Update(Guid id, string name, string phoneNumber, string email);
    }
}