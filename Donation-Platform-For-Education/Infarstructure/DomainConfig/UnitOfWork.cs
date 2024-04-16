using Donation_Platform_For_Education.Domain.Abstarction;
using Donation_Platform_For_Education.Domain.Repository.AdminRepo;
using Donation_Platform_For_Education.Domain.Repository.DonorRepo;
using Donation_Platform_For_Education.Domain.Repository.ItemRepo;
using Donation_Platform_For_Education.Domain.Repository.ItemTypeRepo;
using Donation_Platform_For_Education.Infarstructure.Data;

namespace Donation_Platform_For_Education.Infarstructure.DomainConfig
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly ApplicationDbContext _applicationDbContext;
        public UnitOfWork(IAdminRepository adminRepository, ApplicationDbContext applicationDbContext, IDonorRepository donorRepository, IItemRepository itemRepository, IItemTypeRepository itemTypeRepository)
        {
            _applicationDbContext = applicationDbContext;
            AdminRepository = adminRepository;
            DonorRepository = donorRepository;
            ItemRepository = itemRepository;
            ItemTypeRepository = itemTypeRepository;
        }



        public IAdminRepository AdminRepository { get;  }
        public IDonorRepository DonorRepository { get; }
        public IItemRepository ItemRepository { get; }
        public IItemTypeRepository ItemTypeRepository { get; }

        public async Task<int> save()
        {
           return await _applicationDbContext.SaveChangesAsync();
        }
    }
}
