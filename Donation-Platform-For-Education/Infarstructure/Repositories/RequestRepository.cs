using Ardalis.Result;
using Donation_Platform_For_Education.Domain.Entity.ItemDomain;
using Donation_Platform_For_Education.Domain.Entity.RequestDomain;
using Donation_Platform_For_Education.Domain.Repository.RequestRepo;
using Donation_Platform_For_Education.Infarstructure.Data;
using Donation_Platform_For_Education.Infarstructure.DomainConfig;
using Microsoft.EntityFrameworkCore;

namespace Donation_Platform_For_Education.Infarstructure.Repositories
{
    public class RequestRepository : GenericRepository<Request, RequestId>,IRequestRepository
    {
        public RequestRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Result<bool>> CheckRequestExist(Guid userId,ItemId itemId)
        {
            var result = await _context.Requests.Where(x => x.userId == userId && x.itemId == itemId).AnyAsync();

            return Result.Success(result);
        }
    }
}
