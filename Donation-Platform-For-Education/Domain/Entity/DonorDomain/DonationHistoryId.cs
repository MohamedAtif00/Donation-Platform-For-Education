using Donation_Platform_For_Education.Domain.Abstarction;

namespace Donation_Platform_For_Education.Domain.Entity.DonorDomain
{
    public class DonationHistoryId : ValueObjectId
    {
        protected DonationHistoryId(Guid id) : base(id)
        {
        }

        public static DonationHistoryId Create(Guid id)
        {
            return new DonationHistoryId(id);
        }

        public static DonationHistoryId CreateUnque()
        {
            return new DonationHistoryId(Guid.NewGuid());
        }
    }
}