using Donation_Platform_For_Education.Domain.Abstarction;

namespace Donation_Platform_For_Education.Domain.Entity.ItemTypeDomain
{
    public class ItemType : Entity<ItemTypeId>
    {
        public ItemType(ItemTypeId id, string name) : base(id)
        {
            this.name = name;
        }

        public string name { get; private set; }

        public static ItemType Create(string name)
        {
            return new(ItemTypeId.CreateUnique(), name);
        }

        public void Update(string name)
        {
            this.name = name;
        }
    }
}
