using Donation_Platform_For_Education.Domain.Abstarction;
using Donation_Platform_For_Education.Domain.Entity.DonorDomain;
using Donation_Platform_For_Education.Domain.Entity.ItemTypeDomain;
using Donation_Platform_For_Education.Domain.Entity.RequestDomain;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Donation_Platform_For_Education.Domain.Entity.ItemDomain
{
    public class Item : Entity<ItemId>
    {
        private readonly List<Request> _request = new();
        public Item(ItemId id, ItemTypeId itemTypeId, string name, string description, int? quantity, byte[]? bytes, Guid donorId, byte[]? image) : base(id)
        {
            this.name = name;
            this.description = description;
            this.quantity = quantity;
            this.itemTypeId = itemTypeId;
            this.bytes = bytes;
            this.donorId = donorId;
            this.image = image;
        }
        public string name { get;private set; }
        public string description { get;private set; }
        public int? quantity { get; private set; }
        public byte[]? bytes { get; private set; }
        public byte[]? image { get; private set; }
        public DateTime DonationHistory { get; private init; } = DateTime.UtcNow;

        public ItemType type { get; private set; }
        public ItemTypeId itemTypeId { get; private set; }

        [NotMapped]
        public IReadOnlyCollection<Request> requests => _request;

        public IdentityUser<Guid> Donor { get; private set; }
        public Guid donorId { get; private set; }

        public static Item Create(ItemTypeId itemTypeId,Guid donorId,string name,string description,int? quantity, byte[]? bytes, byte[]? image)
        {
            return new(ItemId.CreateUnique(),itemTypeId,name,description,quantity,bytes,donorId,image);
        }

        public static Item CreateExist(Guid id, Guid itemTypeId, string name, string description, int? quantity, Guid donorId, byte[]? bytes = null, byte[]? image = null)
        {
            return new(ItemId.Create(id), ItemTypeId.Create(itemTypeId), name, description, quantity, bytes, donorId, image);
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
