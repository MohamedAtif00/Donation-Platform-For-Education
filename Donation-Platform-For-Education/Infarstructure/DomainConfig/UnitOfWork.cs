using Donation_Platform_For_Education.Domain.Abstarction;

using Donation_Platform_For_Education.Domain.Repository.ItemRepo;
using Donation_Platform_For_Education.Domain.Repository.ItemTypeRepo;
using Donation_Platform_For_Education.Domain.Repository.RefreshTokenRepo;
using Donation_Platform_For_Education.Domain.Repository.RequestRepo;
using Donation_Platform_For_Education.Infarstructure.Data;

namespace Donation_Platform_For_Education.Infarstructure.DomainConfig
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly ApplicationDbContext _applicationDbContext;
        public UnitOfWork( ApplicationDbContext applicationDbContext,  IItemRepository itemRepository, IItemTypeRepository itemTypeRepository, IRefreshTokenRepository refreshTokenRepository, IRequestRepository requestRepository)
        {
            _applicationDbContext = applicationDbContext;

            ItemRepository = itemRepository;
            ItemTypeRepository = itemTypeRepository;
            RefreshTokenRepository = refreshTokenRepository;
            RequestRepository = requestRepository;
        }




        public IItemRepository ItemRepository { get; }
        public IItemTypeRepository ItemTypeRepository { get; }
        public IRefreshTokenRepository RefreshTokenRepository { get; }
        public IRequestRepository RequestRepository { get; }

        public async Task<int> save()
        {
           return await _applicationDbContext.SaveChangesAsync();
        }
    }
}
