using Ardalis.Result;
using Donation_Platform_For_Education.Domain.Entity.DonorDomain;

namespace Donation_Platform_For_Education.Application.Abstraction.ServiceAbs
{
    public interface IDonorService
    {
        Task<Result<Donor>> Create(string name);
        Task<Result> Delete(Guid id);
        Task<Result<List<Donor>>> GetAll();
        Task<Result<Donor>> GetSingleDonor(Guid id);
        Task<Result<Donor>> Update(Guid id, string name);
    }
}