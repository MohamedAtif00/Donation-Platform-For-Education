using Donation_Platform_For_Education.Domain.Abstarction;
using System.ComponentModel.DataAnnotations.Schema;

namespace Donation_Platform_For_Education.Domain.Entity.DonorDomain
{
    public class Donor : Entity<DonorId>
    {

        public Donor(DonorId id,string name) : base(id)
        {
            this.name = name;
        }

        public string name { get;private set; }

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
