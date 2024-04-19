using Donation_Platform_For_Education.Domain.Abstarction;

namespace Donation_Platform_For_Education.Domain.Entity.RequestDomain
{
    public class RequestId : ValueObjectId
    {
        protected RequestId(Guid id) : base(id)
        {
        }

        public static RequestId Create(Guid id)
        {
            return new(id);
        }

        public static RequestId CreateUnique()
        {
            return new(Guid.NewGuid());
        }
    }
}