using Donation_Platform_For_Education.Controllers;
using Donation_Platform_For_Education.Domain.Abstarction;
using Donation_Platform_For_Education.Domain.Entity.ItemDomain;
using Microsoft.AspNetCore.Identity;

namespace Donation_Platform_For_Education.Domain.Entity.RequestDomain
{
    public class Request : Entity<RequestId>
    {
        public Request(RequestId id, Guid userId, ItemId itemId) : base(id)
        {
            this.userId = userId;
            this.itemId = itemId;
        }

        public IdentityUser<Guid> user { get;private set; }
        public Guid userId { get;private set; }
        public Item item { get; private set; }
        public ItemId itemId { get;private set; }

        public static Request Create(Guid userid ,ItemId itemId) 
        {
            return new(RequestId.CreateUnique(),userid,itemId);
        }

        public void Update()
        { 
        }
    }
}
