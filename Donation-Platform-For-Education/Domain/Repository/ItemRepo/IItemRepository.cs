using Donation_Platform_For_Education.Domain.Abstarction;
using Donation_Platform_For_Education.Domain.Entity.ItemDomain;
using Donation_Platform_For_Education.Domain.Entity.ItemTypeDomain;

namespace Donation_Platform_For_Education.Domain.Repository.ItemRepo
{
    public interface IItemRepository : IGenericRepository<Item, ItemId>
    {
        Task<List<Item>> GetItemsForType(ItemTypeId itemTypeId);
    }
}
