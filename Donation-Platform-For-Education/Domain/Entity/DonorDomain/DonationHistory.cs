using Donation_Platform_For_Education.Domain.Abstarction;

namespace Donation_Platform_For_Education.Domain.Entity.DonorDomain
{
    public class DonationHistory : Entity<DonationHistoryId>
    {
        public DonationHistory(DonationHistoryId id,DonorId donorId ,DateTime date) : base(id)
        {
            this.donorId = donorId;
            Date = date;
        }

        public DateTime Date { get;private init; }

        public Donor donor { get; private set; }
        public DonorId donorId { get; private set; }

        public static DonationHistory Create(DonorId id,DateTime date)
        {
            return new(DonationHistoryId.CreateUnque(),id,date);
        }

    }
}
