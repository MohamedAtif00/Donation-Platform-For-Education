using Donation_Platform_For_Education.Domain.Entity.DonorDomain;
using Donation_Platform_For_Education.Domain.Repository.DonorRepo;
using Donation_Platform_For_Education.Infarstructure.Data;
using Donation_Platform_For_Education.Infarstructure.DomainConfig;

namespace Donation_Platform_For_Education.Infarstructure.Repositories
{
    public class DonorRepository : GenericRepository<Donor, DonorId>,IDonorRepository
    {
        public DonorRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
