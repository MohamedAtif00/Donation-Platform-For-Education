using Donation_Platform_For_Education.Domain.Abstarction;

namespace Donation_Platform_For_Education.Domain.Entity.AdminDomain
{
    public class AdminId : ValueObjectId
    {
        protected AdminId(Guid id) : base(id)
        {
        }

        public static AdminId Create(Guid value)
        {
            return new(value);
        }

        public static AdminId CreateUnque() {
            return new(Guid.NewGuid());
        }
    }


}