using Ardalis.Result;
using Donation_Platform_For_Education.Domain.Abstarction;
using Donation_Platform_For_Education.Domain.Entity.ItemDomain;
using Donation_Platform_For_Education.Domain.Entity.RequestDomain;

namespace Donation_Platform_For_Education.Domain.Repository.RequestRepo
{
    public interface IRequestRepository : IGenericRepository<Request, RequestId>
    {
        Task<Result<bool>> CheckRequestExist(Guid userId, ItemId requestId);
    }
}
