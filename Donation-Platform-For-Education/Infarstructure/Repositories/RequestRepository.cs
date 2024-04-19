using Donation_Platform_For_Education.Domain.Entity.RequestDomain;
using Donation_Platform_For_Education.Domain.Repository.RequestRepo;
using Donation_Platform_For_Education.Infarstructure.Data;
using Donation_Platform_For_Education.Infarstructure.DomainConfig;

namespace Donation_Platform_For_Education.Infarstructure.Repositories
{
    public class RequestRepository : GenericRepository<Request, RequestId>,IRequestRepository
    {
        public RequestRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
