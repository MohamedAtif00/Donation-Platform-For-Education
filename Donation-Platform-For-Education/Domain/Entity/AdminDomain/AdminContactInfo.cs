using Donation_Platform_For_Education.Domain.Abstarction;

namespace Donation_Platform_For_Education.Domain.Entity.AdminDomain
{
    public class AdminContactInfo : ValueObject
    {
        public string? phoneNumber { get;private set; }
        public string? email { get;private set; }

        private AdminContactInfo(string phoneNumber,string email) { 

            this.email = email;
            this.phoneNumber = phoneNumber;

        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return new object[] { phoneNumber, email };
        }

        public static AdminContactInfo Create(string phoneNumber,string email)
        {
            return new AdminContactInfo(phoneNumber,email);
        }
    }
}
