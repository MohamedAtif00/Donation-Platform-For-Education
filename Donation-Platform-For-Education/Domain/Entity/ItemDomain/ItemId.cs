using Donation_Platform_For_Education.Domain.Abstarction;

namespace Donation_Platform_For_Education.Domain.Entity.ItemDomain
{
    public class ItemId : ValueObjectId
    {
        protected ItemId(Guid id) : base(id)
        {
        }

        public static ItemId Create(Guid id)
        {
            return new(id);
        }

        public static ItemId CreateUnique()
        {
            return new(Guid.NewGuid());
        }
    }
}