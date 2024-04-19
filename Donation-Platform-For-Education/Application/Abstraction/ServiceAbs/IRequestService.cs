using Ardalis.Result;
using Donation_Platform_For_Education.Domain.Entity.RequestDomain;

namespace Donation_Platform_For_Education.Application.Abstraction.ServiceAbs
{
    public interface IRequestService
    {
        Task<Result<Request>> Create(Guid userId, Guid itemId);
        Task<Result<List<Request>>> GetAll();
    }
}