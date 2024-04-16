using Donation_Platform_For_Education.Domain.Abstarction;

namespace Donation_Platform_For_Education.Domain.Entity.ItemTypeDomain
{
    public class ItemTypeId : ValueObjectId
    {
        protected ItemTypeId(Guid id) : base(id)
        {
        }

        public static ItemTypeId Create(Guid id)
        {
            return new(id);
        }

        public static ItemTypeId CreateUnique()
        {
            return new(Guid.NewGuid());
        }
    }
}