using Donation_Platform_For_Education.Domain.Abstarction;
using Donation_Platform_For_Education.Domain.Entity.RequestDomain;

namespace Donation_Platform_For_Education.Domain.Repository.RequestRepo
{
    public interface IRequestRepository :IGenericRepository<Request,RequestId>
    {
    }
}
