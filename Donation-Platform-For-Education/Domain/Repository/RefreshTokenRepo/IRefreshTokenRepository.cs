using Donation_Platform_For_Education.Domain.Abstarction;
using Donation_Platform_For_Education.Domain.Entity.RefreshTokenDomain;

namespace Donation_Platform_For_Education.Domain.Repository.RefreshTokenRepo
{
    public interface IRefreshTokenRepository : IGenericRepository<RefreshToken, RefreshTokenId>
    {
        Task<RefreshToken> GetRefreshTokenByUserId(Guid userId);
    }
}
