using Donation_Platform_For_Education.Domain.Abstarction;
using Donation_Platform_For_Education.Domain.Entity.ItemTypeDomain;

namespace Donation_Platform_For_Education.Domain.Entity.ItemDomain
{
    public class Item : Entity<ItemId>
    {
        public Item(ItemId id, ItemTypeId itemTypeId, string name, string description, int? quantity) : base(id)
        {
            this.name = name;
            this.description = description;
            this.quantity = quantity;
            this.itemTypeId = itemTypeId;
        }
        public string name { get;private set; }
        public string description { get;private set; }
        public int? quantity { get; private set; }
        public DateTime DonationHistory { get; private init; } = DateTime.UtcNow;

        public ItemType type { get; private set; }
        public ItemTypeId itemTypeId { get; private set; }

        public static Item Create(ItemTypeId itemTypeId,string name,string description,int? quantity)
        {
            return new(ItemId.CreateUnique(),itemTypeId,name,description,quantity);
        }

        public void UpdateQuantity(int quantity)
        {
            this.quantity = quantity;
        }

        public void UpdateInfo(string name,string description)
        {
            this.name = name;
            this.description = description;
        }



    }
}
