using Donation_Platform_For_Education.Domain.Repository.AdminRepo;
using Donation_Platform_For_Education.Domain.Repository.DonorRepo;
using Donation_Platform_For_Education.Domain.Repository.ItemRepo;
using Donation_Platform_For_Education.Domain.Repository.ItemTypeRepo;
using Donation_Platform_For_Education.Domain.Repository.RefreshTokenRepo;
using Donation_Platform_For_Education.Domain.Repository.RequestRepo;

namespace Donation_Platform_For_Education.Domain.Abstarction
{
    public interface IUnitOfWork
    {
        IAdminRepository AdminRepository { get; }
        IDonorRepository DonorRepository { get; }
        IItemRepository ItemRepository { get; }
        IItemTypeRepository ItemTypeRepository { get; }
        IRefreshTokenRepository RefreshTokenRepository { get; }
        IRequestRepository RequestRepository { get; }

        Task<int> save();
    }
}
