using Donation_Platform_For_Education.Domain.Entity.ItemTypeDomain;
using Donation_Platform_For_Education.Domain.Repository.ItemTypeRepo;
using Donation_Platform_For_Education.Infarstructure.Data;
using Donation_Platform_For_Education.Infarstructure.DomainConfig;

namespace Donation_Platform_For_Education.Infarstructure.Repositories
{
    public class ItemTypeRepository : GenericRepository<ItemType, ItemTypeId>,IItemTypeRepository
    {
        public ItemTypeRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
