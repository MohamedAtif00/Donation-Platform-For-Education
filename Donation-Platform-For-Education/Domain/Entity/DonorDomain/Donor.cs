using Donation_Platform_For_Education.Domain.Abstarction;
using System.ComponentModel.DataAnnotations.Schema;

namespace Donation_Platform_For_Education.Domain.Entity.DonorDomain
{
    public class Donor : Entity<DonorId>
    {
        private List<DonationHistory> _donationHistories;

        public Donor(DonorId id,string name) : base(id)
        {
        }

        public string name { get;private set; }

        [NotMapped]
        public IReadOnlyCollection<DonationHistory> donationHistories => _donationHistories;

        public static Donor Create(string name)
        {
            return new(DonorId.CreateUnque(),name);
        }

        public void Update(string name)
        {
            this.name = name;
        }



    }
}
