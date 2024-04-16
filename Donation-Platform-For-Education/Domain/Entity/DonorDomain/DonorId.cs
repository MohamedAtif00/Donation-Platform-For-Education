using Donation_Platform_For_Education.Domain.Abstarction;

namespace Donation_Platform_For_Education.Domain.Entity.DonorDomain
{
    public class DonorId : ValueObjectId
    {
        protected DonorId(Guid id) : base(id)
        {
        }

        public static DonorId Create(Guid id)
        {
            return new DonorId(id);
        }

        public static DonorId CreateUnque()
        {
            return new DonorId(Guid.NewGuid());
        }
    }
}