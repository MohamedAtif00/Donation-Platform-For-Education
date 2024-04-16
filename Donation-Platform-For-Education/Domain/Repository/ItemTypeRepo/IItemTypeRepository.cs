using Donation_Platform_For_Education.Domain.Abstarction;
using Donation_Platform_For_Education.Domain.Entity.ItemTypeDomain;

namespace Donation_Platform_For_Education.Domain.Repository.ItemTypeRepo
{
    public interface IItemTypeRepository : IGenericRepository<ItemType,ItemTypeId>
    {
    }
}
