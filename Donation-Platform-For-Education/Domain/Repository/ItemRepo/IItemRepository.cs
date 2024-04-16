using Donation_Platform_For_Education.Domain.Abstarction;
using Donation_Platform_For_Education.Domain.Entity.ItemDomain;

namespace Donation_Platform_For_Education.Domain.Repository.ItemRepo
{
    public interface IItemRepository: IGenericRepository<Item,ItemId>
    {
    }
}
