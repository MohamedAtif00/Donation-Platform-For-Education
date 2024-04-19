using Donation_Platform_For_Education.Domain.Entity.ItemDomain;
using Donation_Platform_For_Education.Domain.Repository.ItemRepo;
using Donation_Platform_For_Education.Infarstructure.Data;
using Donation_Platform_For_Education.Infarstructure.DomainConfig;
using Microsoft.EntityFrameworkCore;

namespace Donation_Platform_For_Education.Infarstructure.Repositories
{
    public class ItemRepository : GenericRepository<Item, ItemId>,IItemRepository
    {
        public ItemRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<List<Item>> GetAll()
        {
            var items = await _context.items
                                    .Select(x => Item.CreateExist(x.Id.value,x.itemTypeId.value,x.name,x.description,x.quantity,x.donorId,null,x.image)).ToListAsync();
            return items;
        }

    }
}
