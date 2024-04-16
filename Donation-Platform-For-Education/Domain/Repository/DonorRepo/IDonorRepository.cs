using Donation_Platform_For_Education.Domain.Abstarction;
using Donation_Platform_For_Education.Domain.Entity.DonorDomain;

namespace Donation_Platform_For_Education.Domain.Repository.DonorRepo
{
    public interface IDonorRepository : IGenericRepository<Donor,DonorId>
    {
    }
}
