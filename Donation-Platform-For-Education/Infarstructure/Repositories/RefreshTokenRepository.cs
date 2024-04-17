using Donation_Platform_For_Education.Domain.Entity.RefreshTokenDomain;
using Donation_Platform_For_Education.Domain.Repository.RefreshTokenRepo;
using Donation_Platform_For_Education.Infarstructure.Data;
using Donation_Platform_For_Education.Infarstructure.DomainConfig;
using Microsoft.EntityFrameworkCore;

namespace Donation_Platform_For_Education.Infarstructure.Repositories
{
    public class RefreshTokenRepository : GenericRepository<RefreshToken, RefreshTokenId>,IRefreshTokenRepository
    {
        public RefreshTokenRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<RefreshToken> GetRefreshTokenByUserId(Guid userId)
        {
            return await _context.refreshTokens.FirstOrDefaultAsync(x =>x.UserId == userId);
        }
    }
}
